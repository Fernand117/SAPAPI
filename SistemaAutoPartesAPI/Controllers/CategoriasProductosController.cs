using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasProductosController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public CategoriasProductosController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/CategoriasProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriasProductoDTO>>> GetCategoriasProductos()
        {
            return await _context.CategoriasProductos
                .Select(cp => new CategoriasProductoDTO
                {
                    CategoriaId = cp.CategoriaId,
                    Nombre = cp.Nombre,
                    Descripcion = cp.Descripcion,
                    CategoriaPadreId = cp.CategoriaPadreId
                })
                .ToListAsync();
        }

        // GET: api/CategoriasProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriasProductoDTO>> GetCategoriasProducto(int id)
        {
            var categoriasProducto = await _context.CategoriasProductos.FindAsync(id);

            if (categoriasProducto == null)
            {
                return NotFound();
            }

            return new CategoriasProductoDTO
            {
                CategoriaId = categoriasProducto.CategoriaId,
                Nombre = categoriasProducto.Nombre,
                Descripcion = categoriasProducto.Descripcion,
                CategoriaPadreId = categoriasProducto.CategoriaPadreId
            };
        }

        // PUT: api/CategoriasProductos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriasProducto(int id, CategoriasProductoDTO categoriasProductoDTO)
        {
            if (id != categoriasProductoDTO.CategoriaId)
            {
                return BadRequest();
            }

            var categoriasProducto = await _context.CategoriasProductos.FindAsync(id);
            if (categoriasProducto == null)
            {
                return NotFound();
            }

            categoriasProducto.Nombre = categoriasProductoDTO.Nombre;
            categoriasProducto.Descripcion = categoriasProductoDTO.Descripcion;
            categoriasProducto.CategoriaPadreId = categoriasProductoDTO.CategoriaPadreId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriasProductoExists(id))
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

        // POST: api/CategoriasProductos
        [HttpPost]
        public async Task<ActionResult<CategoriasProductoDTO>> PostCategoriasProducto(CategoriasProductoDTO categoriasProductoDTO)
        {
            var categoriasProducto = new CategoriasProducto
            {
                Nombre = categoriasProductoDTO.Nombre,
                Descripcion = categoriasProductoDTO.Descripcion,
                CategoriaPadreId = categoriasProductoDTO.CategoriaPadreId
            };

            _context.CategoriasProductos.Add(categoriasProducto);
            await _context.SaveChangesAsync();

            categoriasProductoDTO.CategoriaId = categoriasProducto.CategoriaId; // Update DTO with generated ID

            return CreatedAtAction("GetCategoriasProducto", new { id = categoriasProducto.CategoriaId }, categoriasProductoDTO);
        }

        // DELETE: api/CategoriasProductos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriasProducto(int id)
        {
            var categoriasProducto = await _context.CategoriasProductos.FindAsync(id);
            if (categoriasProducto == null)
            {
                return NotFound();
            }

            _context.CategoriasProductos.Remove(categoriasProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriasProductoExists(int id)
        {
            return _context.CategoriasProductos.Any(e => e.CategoriaId == id);
        }
    }
}