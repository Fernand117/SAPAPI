using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacorasController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public BitacorasController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/Bitacoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BitacoraDTO>>> GetBitacoras()
        {
            return await _context.Bitacoras
                .Select(b => new BitacoraDTO
                {
                    BitacoraId = b.BitacoraId,
                    FechaHora = b.FechaHora,
                    UsuarioId = b.UsuarioId,
                    SucursalId = b.SucursalId,
                    Accion = b.Accion,
                    Tabla = b.Tabla,
                    RegistroId = b.RegistroId,
                    Detalles = b.Detalles,
                    Ip = b.Ip
                })
                .ToListAsync();
        }

        // GET: api/Bitacoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BitacoraDTO>> GetBitacora(int id)
        {
            var bitacora = await _context.Bitacoras.FindAsync(id);

            if (bitacora == null)
            {
                return NotFound();
            }

            return new BitacoraDTO
            {
                BitacoraId = bitacora.BitacoraId,
                FechaHora = bitacora.FechaHora,
                UsuarioId = bitacora.UsuarioId,
                SucursalId = bitacora.SucursalId,
                Accion = bitacora.Accion,
                Tabla = bitacora.Tabla,
                RegistroId = bitacora.RegistroId,
                Detalles = bitacora.Detalles,
                Ip = bitacora.Ip
            };
        }

        // PUT: api/Bitacoras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBitacora(int id, BitacoraDTO bitacoraDTO)
        {
            if (id != bitacoraDTO.BitacoraId)
            {
                return BadRequest();
            }

            var bitacora = await _context.Bitacoras.FindAsync(id);
            if (bitacora == null)
            {
                return NotFound();
            }

            bitacora.FechaHora = bitacoraDTO.FechaHora;
            bitacora.UsuarioId = bitacoraDTO.UsuarioId;
            bitacora.SucursalId = bitacoraDTO.SucursalId;
            bitacora.Accion = bitacoraDTO.Accion;
            bitacora.Tabla = bitacoraDTO.Tabla;
            bitacora.RegistroId = bitacoraDTO.RegistroId;
            bitacora.Detalles = bitacoraDTO.Detalles;
            bitacora.Ip = bitacoraDTO.Ip;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BitacoraExists(id))
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

        // POST: api/Bitacoras
        [HttpPost]
        public async Task<ActionResult<BitacoraDTO>> PostBitacora(BitacoraDTO bitacoraDTO)
        {
            var bitacora = new Bitacora
            {
                FechaHora = bitacoraDTO.FechaHora,
                UsuarioId = bitacoraDTO.UsuarioId,
                SucursalId = bitacoraDTO.SucursalId,
                Accion = bitacoraDTO.Accion,
                Tabla = bitacoraDTO.Tabla,
                RegistroId = bitacoraDTO.RegistroId,
                Detalles = bitacoraDTO.Detalles,
                Ip = bitacoraDTO.Ip
            };

            _context.Bitacoras.Add(bitacora);
            await _context.SaveChangesAsync();

            bitacoraDTO.BitacoraId = bitacora.BitacoraId; // Update DTO with generated ID

            return CreatedAtAction("GetBitacora", new { id = bitacora.BitacoraId }, bitacoraDTO);
        }

        // DELETE: api/Bitacoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBitacora(int id)
        {
            var bitacora = await _context.Bitacoras.FindAsync(id);
            if (bitacora == null)
            {
                return NotFound();
            }

            _context.Bitacoras.Remove(bitacora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BitacoraExists(int id)
        {
            return _context.Bitacoras.Any(e => e.BitacoraId == id);
        }
    }
}