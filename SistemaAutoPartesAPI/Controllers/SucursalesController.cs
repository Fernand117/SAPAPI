using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public SucursalesController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/Sucursales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SucursalDTO>>> GetSucursales()
        {
            var sucursales = await _context.Sucursales
                .Select(s => new SucursalDTO
                {
                    SucursalId = s.SucursalId,
                    Nombre = s.Nombre,
                    Direccion = s.Direccion,
                    Ciudad = s.Ciudad,
                    Estado = s.Estado,
                    Telefono = s.Telefono
                })
                .ToListAsync();

            return Ok(sucursales);
        }

        // GET: api/Sucursales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SucursalDTO>> GetSucursal(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);

            if (sucursal == null)
            {
                return NotFound();
            }

            var sucursalDTO = new SucursalDTO
            {
                SucursalId = sucursal.SucursalId,
                Nombre = sucursal.Nombre,
                Direccion = sucursal.Direccion,
                Ciudad = sucursal.Ciudad,
                Estado = sucursal.Estado,
                Telefono = sucursal.Telefono
            };

            return Ok(sucursalDTO);
        }

        // POST: api/Sucursales
        [HttpPost]
        public async Task<ActionResult<SucursalDTO>> PostSucursal(SucursalDTO sucursalDTO)
        {
            var sucursal = new Sucursale
            {
                Nombre = sucursalDTO.Nombre,
                Direccion = sucursalDTO.Direccion,
                Ciudad = sucursalDTO.Ciudad,
                Estado = sucursalDTO.Estado,
                Telefono = sucursalDTO.Telefono
            };

            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();

            sucursalDTO.SucursalId = sucursal.SucursalId; // Update DTO with generated ID

            return CreatedAtAction("GetSucursal", new { id = sucursal.SucursalId }, sucursalDTO);
        }

        // PUT: api/Sucursales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSucursal(int id, SucursalDTO sucursalDTO)
        {
            if (id != sucursalDTO.SucursalId)
            {
                return BadRequest();
            }

            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            sucursal.Nombre = sucursalDTO.Nombre;
            sucursal.Direccion = sucursalDTO.Direccion;
            sucursal.Ciudad = sucursalDTO.Ciudad;
            sucursal.Estado = sucursalDTO.Estado;
            sucursal.Telefono = sucursalDTO.Telefono;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalExists(id))
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

        // DELETE: api/Sucursales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursal(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            _context.Sucursales.Remove(sucursal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SucursalExists(int id)
        {
            return _context.Sucursales.Any(e => e.SucursalId == id);
        }
    }
}