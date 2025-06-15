using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public VentasController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentaDTO>>> GetVentas()
        {
            var ventas = await _context.Ventas
                .Select(v => new VentaDTO
                {
                    VentaId = v.VentaId,
                    UsuarioId = v.UsuarioId,
                    ClienteId = v.ClienteId,
                    SucursalId = v.SucursalId,
                    Fecha = v.Fecha,
                    Total = v.Total,
                    FormaPago = v.FormaPago,
                    Notas = v.Notas,
                    FirmaUrl = v.FirmaUrl,
                    UbicacionGeo = v.UbicacionGeo
                })
                .ToListAsync();

            return Ok(ventas);
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentaDTO>> GetVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);

            if (venta == null)
            {
                return NotFound();
            }

            var ventaDTO = new VentaDTO
            {
                VentaId = venta.VentaId,
                UsuarioId = venta.UsuarioId,
                ClienteId = venta.ClienteId,
                SucursalId = venta.SucursalId,
                Fecha = venta.Fecha,
                Total = venta.Total,
                FormaPago = venta.FormaPago,
                Notas = venta.Notas,
                FirmaUrl = venta.FirmaUrl,
                UbicacionGeo = venta.UbicacionGeo
            };

            return Ok(ventaDTO);
        }

        // POST: api/Ventas
        [HttpPost]
        public async Task<ActionResult<VentaDTO>> PostVenta(VentaDTO ventaDTO)
        {
            var venta = new Venta
            {
                UsuarioId = ventaDTO.UsuarioId,
                ClienteId = ventaDTO.ClienteId,
                SucursalId = ventaDTO.SucursalId,
                Fecha = ventaDTO.Fecha,
                Total = ventaDTO.Total,
                FormaPago = ventaDTO.FormaPago,
                Notas = ventaDTO.Notas,
                FirmaUrl = ventaDTO.FirmaUrl,
                UbicacionGeo = ventaDTO.UbicacionGeo
            };

            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            ventaDTO.VentaId = venta.VentaId; // Update DTO with generated ID

            return CreatedAtAction("GetVenta", new { id = venta.VentaId }, ventaDTO);
        }

        // PUT: api/Ventas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, VentaDTO ventaDTO)
        {
            if (id != ventaDTO.VentaId)
            {
                return BadRequest();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }

            venta.UsuarioId = ventaDTO.UsuarioId;
            venta.ClienteId = ventaDTO.ClienteId;
            venta.SucursalId = ventaDTO.SucursalId;
            venta.Fecha = ventaDTO.Fecha;
            venta.Total = ventaDTO.Total;
            venta.FormaPago = ventaDTO.FormaPago;
            venta.Notas = ventaDTO.Notas;
            venta.FirmaUrl = ventaDTO.FirmaUrl;
            venta.UbicacionGeo = ventaDTO.UbicacionGeo;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
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

        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }

            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.VentaId == id);
        }
    }
}