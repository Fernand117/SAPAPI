using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioVendedoresController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public InventarioVendedoresController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/InventarioVendedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventarioVendedorDTO>>> GetInventarioVendedores()
        {
            return await _context.InventarioVendedors
                .Select(iv => new InventarioVendedorDTO
                {
                    UsuarioId = iv.UsuarioId,
                    ProductoId = iv.ProductoId,
                    SucursalId = iv.SucursalId,
                    Cantidad = iv.Cantidad
                })
                .ToListAsync();
        }

        // GET: api/InventarioVendedores/5
        [HttpGet("{usuarioId}/{productoId}/{sucursalId}")]
        public async Task<ActionResult<InventarioVendedorDTO>> GetInventarioVendedor(int usuarioId, int productoId, int sucursalId)
        {
            var inventarioVendedor = await _context.InventarioVendedors.FindAsync(usuarioId, productoId, sucursalId);

            if (inventarioVendedor == null)
            {
                return NotFound();
            }

            return new InventarioVendedorDTO
            {
                UsuarioId = inventarioVendedor.UsuarioId,
                ProductoId = inventarioVendedor.ProductoId,
                SucursalId = inventarioVendedor.SucursalId,
                Cantidad = inventarioVendedor.Cantidad
            };
        }

        // PUT: api/InventarioVendedores/5
        [HttpPut("{usuarioId}/{productoId}/{sucursalId}")]
        public async Task<IActionResult> PutInventarioVendedor(int usuarioId, int productoId, int sucursalId, InventarioVendedorDTO inventarioVendedorDTO)
        {
            if (usuarioId != inventarioVendedorDTO.UsuarioId || productoId != inventarioVendedorDTO.ProductoId || sucursalId != inventarioVendedorDTO.SucursalId)
            {
                return BadRequest();
            }

            var inventarioVendedor = await _context.InventarioVendedors.FindAsync(usuarioId, productoId, sucursalId);
            if (inventarioVendedor == null)
            {
                return NotFound();
            }

            inventarioVendedor.Cantidad = inventarioVendedorDTO.Cantidad;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioVendedorExists(usuarioId, productoId, sucursalId))
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

        // POST: api/InventarioVendedores
        [HttpPost]
        public async Task<ActionResult<InventarioVendedorDTO>> PostInventarioVendedor(InventarioVendedorDTO inventarioVendedorDTO)
        {
            var inventarioVendedor = new InventarioVendedor
            {
                UsuarioId = inventarioVendedorDTO.UsuarioId,
                ProductoId = inventarioVendedorDTO.ProductoId,
                SucursalId = inventarioVendedorDTO.SucursalId,
                Cantidad = inventarioVendedorDTO.Cantidad
            };

            _context.InventarioVendedors.Add(inventarioVendedor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InventarioVendedorExists(inventarioVendedor.UsuarioId, inventarioVendedor.ProductoId, inventarioVendedor.SucursalId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInventarioVendedor", new { usuarioId = inventarioVendedor.UsuarioId, productoId = inventarioVendedor.ProductoId, sucursalId = inventarioVendedor.SucursalId }, inventarioVendedorDTO);
        }

        // DELETE: api/InventarioVendedores/5
        [HttpDelete("{usuarioId}/{productoId}/{sucursalId}")]
        public async Task<IActionResult> DeleteInventarioVendedor(int usuarioId, int productoId, int sucursalId)
        {
            var inventarioVendedor = await _context.InventarioVendedors.FindAsync(usuarioId, productoId, sucursalId);
            if (inventarioVendedor == null)
            {
                return NotFound();
            }

            _context.InventarioVendedors.Remove(inventarioVendedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventarioVendedorExists(int usuarioId, int productoId, int sucursalId)
        {
            return _context.InventarioVendedors.Any(e => e.UsuarioId == usuarioId && e.ProductoId == productoId && e.SucursalId == sucursalId);
        }
    }
}