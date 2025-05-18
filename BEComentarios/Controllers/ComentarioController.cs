using Microsoft.AspNetCore.Mvc;
using BEComentarios.Models;
using BEComentarios.Data; //Importacion del ApplicationDbContext
using Microsoft.EntityFrameworkCore; 

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

        private readonly ApplicationDbContext _context; //Variable Privada 
        
        public ComentariosController(ApplicationDbContext context) //Constructor 
        {
            _context = context;
        }

        // GET: api/comentarios
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listComentarios = await _context.Comentarios.ToListAsync();
                return Ok(listComentarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/comentarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var comentario = await _context.Comentarios.FindAsync(id);

                if (comentario == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(comentario);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST: api/comentarios
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comentario comentario)
        {
            try
            {
                _context.Add(comentario);
                await _context.SaveChangesAsync();

                return Ok(comentario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/comentarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Comentario comentario)
        {
            try
            {
                if (id != comentario.Id)
                {
                    return BadRequest();
                }
                else
                {
                    _context.Update(comentario);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Comentario Actualizado con exito!" });
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/comentarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var comentario = await _context.Comentarios.FindAsync(id);
                if (comentario == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Comentarios.Remove(comentario);
                    await _context.SaveChangesAsync();

                    return Ok(new { message = "Comentario eliminado con exito!" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
