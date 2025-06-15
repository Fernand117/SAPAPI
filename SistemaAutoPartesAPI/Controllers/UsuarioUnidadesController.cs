using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioUnidadesController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public UsuarioUnidadesController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioUnidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioUnidadDTO>>> GetUsuarioUnidades()
        {
            return await _context.UsuarioUnidads
                .Select(x => new UsuarioUnidadDTO
                {
                    UsuarioId = x.UsuarioId,
                    UnidadId = x.UnidadId,
                    SucursalId = x.SucursalId,
                    FechaAsignacion = x.FechaAsignacion
                })
                .ToListAsync();
        }

        // GET: api/UsuarioUnidades/5/6
        [HttpGet("{usuarioId}/{unidadId}")]
        public async Task<ActionResult<UsuarioUnidadDTO>> GetUsuarioUnidad(int usuarioId, int unidadId)
        {
            var usuarioUnidad = await _context.UsuarioUnidads.FindAsync(usuarioId, unidadId);

            if (usuarioUnidad == null)
            {
                return NotFound();
            }

            return new UsuarioUnidadDTO
            {
                UsuarioId = usuarioUnidad.UsuarioId,
                UnidadId = usuarioUnidad.UnidadId,
                SucursalId = usuarioUnidad.SucursalId,
                FechaAsignacion = usuarioUnidad.FechaAsignacion
            };
        }

        // PUT: api/UsuarioUnidades/5/6
        [HttpPut("{usuarioId}/{unidadId}")]
        public async Task<IActionResult> PutUsuarioUnidad(int usuarioId, int unidadId, UsuarioUnidadDTO usuarioUnidadDTO)
        {
            if (usuarioId != usuarioUnidadDTO.UsuarioId || unidadId != usuarioUnidadDTO.UnidadId)
            {
                return BadRequest();
            }

            var usuarioUnidad = await _context.UsuarioUnidads.FindAsync(usuarioId, unidadId);
            if (usuarioUnidad == null)
            {
                return NotFound();
            }

            usuarioUnidad.SucursalId = usuarioUnidadDTO.SucursalId;
            usuarioUnidad.FechaAsignacion = usuarioUnidadDTO.FechaAsignacion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioUnidadExists(usuarioId, unidadId))
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

        // POST: api/UsuarioUnidades
        [HttpPost]
        public async Task<ActionResult<UsuarioUnidadDTO>> PostUsuarioUnidad(UsuarioUnidadDTO usuarioUnidadDTO)
        {
            var usuarioUnidad = new UsuarioUnidad
            {
                UsuarioId = usuarioUnidadDTO.UsuarioId,
                UnidadId = usuarioUnidadDTO.UnidadId,
                SucursalId = usuarioUnidadDTO.SucursalId,
                FechaAsignacion = usuarioUnidadDTO.FechaAsignacion
            };

            _context.UsuarioUnidads.Add(usuarioUnidad);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuarioUnidadExists(usuarioUnidad.UsuarioId, usuarioUnidad.UnidadId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuarioUnidad", new { usuarioId = usuarioUnidad.UsuarioId, unidadId = usuarioUnidad.UnidadId }, usuarioUnidadDTO);
        }

        // DELETE: api/UsuarioUnidades/5/6
        [HttpDelete("{usuarioId}/{unidadId}")]
        public async Task<IActionResult> DeleteUsuarioUnidad(int usuarioId, int unidadId)
        {
            var usuarioUnidad = await _context.UsuarioUnidads.FindAsync(usuarioId, unidadId);
            if (usuarioUnidad == null)
            {
                return NotFound();
            }

            _context.UsuarioUnidads.Remove(usuarioUnidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioUnidadExists(int usuarioId, int unidadId)
        {
            return _context.UsuarioUnidads.Any(e => e.UsuarioId == usuarioId && e.UnidadId == unidadId);
        }
    }
}