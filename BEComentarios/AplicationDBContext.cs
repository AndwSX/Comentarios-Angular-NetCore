// File: Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using BEComentarios.Models;

namespace BEComentarios.Data
{
    /// <summary>
    ///  Contexto principal de EF Core.  Registra las entidades y configura
    ///  el esquema cuando sea necesario (por convención o con Fluent API).
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        // El ctor recibe las opciones (cadena de conexión, proveedor, etc.)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // DbSet ↔ tabla Comentarios
        public DbSet<Comentario> Comentarios => Set<Comentario>();

        // Aquí puedes afinar mapeos con Fluent API si lo necesitas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1) Llama primero a la versión base (buena práctica)
            base.OnModelCreating(modelBuilder);

            // 2) Configuración de la entidad Comentario
            modelBuilder.Entity<Comentario>(entity =>
            {
                // 2a) Propiedad Titulo
                entity.Property(c => c.Titulo)   // selecciona la propiedad
                    .HasMaxLength(200)         // crea una columna VARCHAR(200)
                    .IsRequired();             // NOT NULL en la BD

                // 2b) Propiedad Creador
                entity.Property(c => c.Creador)
                    .HasMaxLength(100)         // VARCHAR(100)
                    .IsRequired();             // NOT NULL

                // 2c) Propiedad Texto
                entity.Property(c => c.Texto)
                    .HasColumnType("text");    // usa tipo TEXT (ilimitado) en MySQL
            });
        }
    }
}