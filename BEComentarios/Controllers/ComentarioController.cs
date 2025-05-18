using Microsoft.AspNetCore.Mvc;
using BEComentarios.Models;

namespace BEComentarios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentariosController : ControllerBase
    {
        // Simulamos una base de datos en memoria
        private static readonly List<Comentario> comentarios = new List<Comentario>()
        {
            new Comentario { Id = 1, Titulo = "Primer Comentario", Creador = "Ana", FechaCreacion = DateTime.Now.AddDays(-2), Texto = "Hola mundo" },
            new Comentario { Id = 2, Titulo = "Segundo Comentario", Creador = "Luis", FechaCreacion = DateTime.Now.AddDays(-1), Texto = "Contenido ejemplo" }
        };

        // GET: api/comentarios
        [HttpGet]
        public ActionResult<IEnumerable<Comentario>> GetComentarios()
        {
            return Ok(comentarios);
        }

        // GET: api/comentarios/5
        [HttpGet("{id}")]
        public ActionResult<Comentario> GetComentario(int id)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == id);
            if (comentario == null)
                return NotFound();

            return Ok(comentario);
        }

        // POST: api/comentarios
        [HttpPost]
        public ActionResult<Comentario> CrearComentario([FromBody] Comentario nuevoComentario)
        {
            nuevoComentario.Id = comentarios.Any() ? comentarios.Max(c => c.Id) + 1 : 1;
            nuevoComentario.FechaCreacion = DateTime.Now;
            comentarios.Add(nuevoComentario);

            return CreatedAtAction(nameof(GetComentario), new { id = nuevoComentario.Id }, nuevoComentario);
        }

        // PUT: api/comentarios/5
        [HttpPut("{id}")]
        public IActionResult ActualizarComentario(int id, [FromBody] Comentario actualizadoComentario)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == id);
            if (comentario == null)
                return NotFound();

            comentario.Titulo = actualizadoComentario.Titulo;
            comentario.Creador = actualizadoComentario.Creador;
            comentario.Texto = actualizadoComentario.Texto;
            // No actualizamos la fecha de creación

            return NoContent();
        }

        // DELETE: api/comentarios/5
        [HttpDelete("{id}")]
        public IActionResult BorrarComentario(int id)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == id);
            if (comentario == null)
                return NotFound();

            comentarios.Remove(comentario);
            return NoContent();
        }
    }
}
