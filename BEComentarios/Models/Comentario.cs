using System.ComponentModel.DataAnnotations;

namespace BEComentarios.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; } = string.Empty;
        [Required]
        public string Creador { get; set; } = string.Empty;
        [Required]
        public string Texto { get; set; } = string.Empty;
        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}
