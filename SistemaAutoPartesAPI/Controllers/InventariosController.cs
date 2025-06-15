using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventariosController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public InventariosController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/Inventarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventarioDTO>>> GetInventarios()
        {
            return await _context.Inventarios
                .Select(i => new InventarioDTO
                {
                    InventarioId = i.InventarioId,
                    ProductoId = i.ProductoId,
                    SucursalId = i.SucursalId,
                    Cantidad = i.Cantidad
                })
                .ToListAsync();
        }

        // GET: api/Inventarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventarioDTO>> GetInventario(int id)
        {
            var inventario = await _context.Inventarios.FindAsync(id);

            if (inventario == null)
            {
                return NotFound();
            }

            return new InventarioDTO
            {
                InventarioId = inventario.InventarioId,
                ProductoId = inventario.ProductoId,
                SucursalId = inventario.SucursalId,
                Cantidad = inventario.Cantidad
            };
        }

        // PUT: api/Inventarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventario(int id, InventarioDTO inventarioDTO)
        {
            if (id != inventarioDTO.InventarioId)
            {
                return BadRequest();
            }

            var inventario = await _context.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }

            inventario.ProductoId = inventarioDTO.ProductoId;
            inventario.SucursalId = inventarioDTO.SucursalId;
            inventario.Cantidad = inventarioDTO.Cantidad;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioExists(id))
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

        // POST: api/Inventarios
        [HttpPost]
        public async Task<ActionResult<InventarioDTO>> PostInventario(InventarioDTO inventarioDTO)
        {
            var inventario = new Inventario
            {
                ProductoId = inventarioDTO.ProductoId,
                SucursalId = inventarioDTO.SucursalId,
                Cantidad = inventarioDTO.Cantidad
            };

            _context.Inventarios.Add(inventario);
            await _context.SaveChangesAsync();

            inventarioDTO.InventarioId = inventario.InventarioId; // Update DTO with generated ID

            return CreatedAtAction("GetInventario", new { id = inventario.InventarioId }, inventarioDTO);
        }

        // DELETE: api/Inventarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventario(int id)
        {
            var inventario = await _context.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }

            _context.Inventarios.Remove(inventario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventarioExists(int id)
        {
            return _context.Inventarios.Any(e => e.InventarioId == id);
        }
    }
}