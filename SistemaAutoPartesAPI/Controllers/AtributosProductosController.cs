using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtributosProductosController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public AtributosProductosController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/AtributosProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtributosProductoDTO>>> GetAtributosProductos()
        {
            return await _context.AtributosProductos
                .Select(ap => new AtributosProductoDTO
                {
                    AtributoId = ap.AtributoId,
                    Nombre = ap.Nombre,
                    TipoDato = ap.TipoDato,
                    CategoriaId = ap.CategoriaId
                })
                .ToListAsync();
        }

        // GET: api/AtributosProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AtributosProductoDTO>> GetAtributosProducto(int id)
        {
            var atributosProducto = await _context.AtributosProductos.FindAsync(id);

            if (atributosProducto == null)
            {
                return NotFound();
            }

            return new AtributosProductoDTO
            {
                AtributoId = atributosProducto.AtributoId,
                Nombre = atributosProducto.Nombre,
                TipoDato = atributosProducto.TipoDato,
                CategoriaId = atributosProducto.CategoriaId
            };
        }

        // PUT: api/AtributosProductos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtributosProducto(int id, AtributosProductoDTO atributosProductoDTO)
        {
            if (id != atributosProductoDTO.AtributoId)
            {
                return BadRequest();
            }

            var atributosProducto = await _context.AtributosProductos.FindAsync(id);
            if (atributosProducto == null)
            {
                return NotFound();
            }

            atributosProducto.Nombre = atributosProductoDTO.Nombre;
            atributosProducto.TipoDato = atributosProductoDTO.TipoDato;
            atributosProducto.CategoriaId = atributosProductoDTO.CategoriaId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtributosProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AtributosProductos
        [HttpPost]
        public async Task<ActionResult<AtributosProductoDTO>> PostAtributosProducto(AtributosProductoDTO atributosProductoDTO)
        {
            var atributosProducto = new AtributosProducto
            {
                Nombre = atributosProductoDTO.Nombre,
                TipoDato = atributosProductoDTO.TipoDato,
                CategoriaId = atributosProductoDTO.CategoriaId
            };

            _context.AtributosProductos.Add(atributosProducto);
            await _context.SaveChangesAsync();

            atributosProductoDTO.AtributoId = atributosProducto.AtributoId; // Update DTO with generated ID

            return CreatedAtAction("GetAtributosProducto", new { id = atributosProducto.AtributoId }, atributosProductoDTO);
        }

        // DELETE: api/AtributosProductos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtributosProducto(int id)
        {
            var atributosProducto = await _context.AtributosProductos.FindAsync(id);
            if (atributosProducto == null)
            {
                return NotFound();
            }

            _context.AtributosProductos.Remove(atributosProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtributosProductoExists(int id)
        {
            return _context.AtributosProductos.Any(e => e.AtributoId == id);
        }
    }
}