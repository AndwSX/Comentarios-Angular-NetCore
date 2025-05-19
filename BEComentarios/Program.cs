// Program.cs
using BEComentarios.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// -------------------------------------------------------------
// 1) Servicios
// -------------------------------------------------------------
builder.Services.AddControllers();

// 1a) Conexión a MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 1b) CORS  ―――――――――――――――――――――――――――――――――――――――――――――――――――
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "DevCors",
        policy =>
        {
            policy.WithOrigins(
                    "http://localhost:4200",  // Angular CLI
                    "http://localhost:5173",  // Vite default
                    "http://localhost:5174")  // Vite preview (si lo usas)
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();       // ← Solo si usarás cookies
        });
});

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -------------------------------------------------------------
// 2) Construir la aplicación
// -------------------------------------------------------------
var app = builder.Build();

// -------------------------------------------------------------
// 3) Middleware
// -------------------------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitar CORS *antes* de los endpoints
app.UseCors("DevCors");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

