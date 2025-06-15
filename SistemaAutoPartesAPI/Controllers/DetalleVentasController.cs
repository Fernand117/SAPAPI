using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentasController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public DetalleVentasController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/DetalleVentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleVentumDTO>>> GetDetalleVentas()
        {
            var detalleVentas = await _context.DetalleVenta
                .Select(d => new DetalleVentumDTO
                {
                    DetalleId = d.DetalleId,
                    VentaId = d.VentaId,
                    ProductoId = d.ProductoId,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario,
                    Subtotal = d.Subtotal
                })
                .ToListAsync();

            return Ok(detalleVentas);
        }

        // GET: api/DetalleVentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleVentumDTO>> GetDetalleVentum(int id)
        {
            var detalleVentum = await _context.DetalleVenta.FindAsync(id);

            if (detalleVentum == null)
            {
                return NotFound();
            }

            var detalleVentumDTO = new DetalleVentumDTO
            {
                DetalleId = detalleVentum.DetalleId,
                VentaId = detalleVentum.VentaId,
                ProductoId = detalleVentum.ProductoId,
                Cantidad = detalleVentum.Cantidad,
                PrecioUnitario = detalleVentum.PrecioUnitario,
                Subtotal = detalleVentum.Subtotal
            };

            return Ok(detalleVentumDTO);
        }

        // POST: api/DetalleVentas
        [HttpPost]
        public async Task<ActionResult<DetalleVentumDTO>> PostDetalleVentum(DetalleVentumDTO detalleVentumDTO)
        {
            var detalleVentum = new DetalleVentum
            {
                VentaId = detalleVentumDTO.VentaId,
                ProductoId = detalleVentumDTO.ProductoId,
                Cantidad = detalleVentumDTO.Cantidad,
                PrecioUnitario = detalleVentumDTO.PrecioUnitario,
                Subtotal = detalleVentumDTO.Subtotal
            };

            _context.DetalleVenta.Add(detalleVentum);
            await _context.SaveChangesAsync();

            detalleVentumDTO.DetalleId = detalleVentum.DetalleId; // Update DTO with generated ID

            return CreatedAtAction("GetDetalleVentum", new { id = detalleVentum.DetalleId }, detalleVentumDTO);
        }

        // PUT: api/DetalleVentas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleVentum(int id, DetalleVentumDTO detalleVentumDTO)
        {
            if (id != detalleVentumDTO.DetalleId)
            {
                return BadRequest();
            }

            var detalleVentum = await _context.DetalleVenta.FindAsync(id);
            if (detalleVentum == null)
            {
                return NotFound();
            }

            detalleVentum.VentaId = detalleVentumDTO.VentaId;
            detalleVentum.ProductoId = detalleVentumDTO.ProductoId;
            detalleVentum.Cantidad = detalleVentumDTO.Cantidad;
            detalleVentum.PrecioUnitario = detalleVentumDTO.PrecioUnitario;
            detalleVentum.Subtotal = detalleVentumDTO.Subtotal;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleVentumExists(id))
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

        // DELETE: api/DetalleVentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleVentum(int id)
        {
            var detalleVentum = await _context.DetalleVenta.FindAsync(id);
            if (detalleVentum == null)
            {
                return NotFound();
            }

            _context.DetalleVenta.Remove(detalleVentum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleVentumExists(int id)
        {
            return _context.DetalleVenta.Any(e => e.DetalleId == id);
        }
    }
}