using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosInventariosController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public MovimientosInventariosController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/MovimientosInventarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimientosInventarioDTO>>> GetMovimientosInventarios()
        {
            return await _context.MovimientosInventarios
                .Select(mi => new MovimientosInventarioDTO
                {
                    MovimientoId = mi.MovimientoId,
                    ProductoId = mi.ProductoId,
                    SucursalId = mi.SucursalId,
                    FechaHora = mi.FechaHora,
                    TipoMovimiento = mi.TipoMovimiento,
                    Cantidad = mi.Cantidad,
                    ReferenciaId = mi.ReferenciaId,
                    Origen = mi.Origen,
                    UsuarioId = mi.UsuarioId,
                    Notas = mi.Notas
                })
                .ToListAsync();
        }

        // GET: api/MovimientosInventarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientosInventarioDTO>> GetMovimientosInventario(int id)
        {
            var movimientosInventario = await _context.MovimientosInventarios.FindAsync(id);

            if (movimientosInventario == null)
            {
                return NotFound();
            }

            return new MovimientosInventarioDTO
            {
                MovimientoId = movimientosInventario.MovimientoId,
                ProductoId = movimientosInventario.ProductoId,
                SucursalId = movimientosInventario.SucursalId,
                FechaHora = movimientosInventario.FechaHora,
                TipoMovimiento = movimientosInventario.TipoMovimiento,
                Cantidad = movimientosInventario.Cantidad,
                ReferenciaId = movimientosInventario.ReferenciaId,
                Origen = movimientosInventario.Origen,
                UsuarioId = movimientosInventario.UsuarioId,
                Notas = movimientosInventario.Notas
            };
        }

        // PUT: api/MovimientosInventarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimientosInventario(int id, MovimientosInventarioDTO movimientosInventarioDTO)
        {
            if (id != movimientosInventarioDTO.MovimientoId)
            {
                return BadRequest();
            }

            var movimientosInventario = await _context.MovimientosInventarios.FindAsync(id);
            if (movimientosInventario == null)
            {
                return NotFound();
            }

            movimientosInventario.ProductoId = movimientosInventarioDTO.ProductoId;
            movimientosInventario.SucursalId = movimientosInventarioDTO.SucursalId;
            movimientosInventario.FechaHora = movimientosInventarioDTO.FechaHora;
            movimientosInventario.TipoMovimiento = movimientosInventarioDTO.TipoMovimiento;
            movimientosInventario.Cantidad = movimientosInventarioDTO.Cantidad;
            movimientosInventario.ReferenciaId = movimientosInventarioDTO.ReferenciaId;
            movimientosInventario.Origen = movimientosInventarioDTO.Origen;
            movimientosInventario.UsuarioId = movimientosInventarioDTO.UsuarioId;
            movimientosInventario.Notas = movimientosInventarioDTO.Notas;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientosInventarioExists(id))
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

        // POST: api/MovimientosInventarios
        [HttpPost]
        public async Task<ActionResult<MovimientosInventarioDTO>> PostMovimientosInventario(MovimientosInventarioDTO movimientosInventarioDTO)
        {
            var movimientosInventario = new MovimientosInventario
            {
                ProductoId = movimientosInventarioDTO.ProductoId,
                SucursalId = movimientosInventarioDTO.SucursalId,
                FechaHora = movimientosInventarioDTO.FechaHora,
                TipoMovimiento = movimientosInventarioDTO.TipoMovimiento,
                Cantidad = movimientosInventarioDTO.Cantidad,
                ReferenciaId = movimientosInventarioDTO.ReferenciaId,
                Origen = movimientosInventarioDTO.Origen,
                UsuarioId = movimientosInventarioDTO.UsuarioId,
                Notas = movimientosInventarioDTO.Notas
            };

            _context.MovimientosInventarios.Add(movimientosInventario);
            await _context.SaveChangesAsync();

            movimientosInventarioDTO.MovimientoId = movimientosInventario.MovimientoId; // Update DTO with generated ID

            return CreatedAtAction("GetMovimientosInventario", new { id = movimientosInventario.MovimientoId }, movimientosInventarioDTO);
        }

        // DELETE: api/MovimientosInventarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimientosInventario(int id)
        {
            var movimientosInventario = await _context.MovimientosInventarios.FindAsync(id);
            if (movimientosInventario == null)
            {
                return NotFound();
            }

            _context.MovimientosInventarios.Remove(movimientosInventario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovimientosInventarioExists(int id)
        {
            return _context.MovimientosInventarios.Any(e => e.MovimientoId == id);
        }
    }
}