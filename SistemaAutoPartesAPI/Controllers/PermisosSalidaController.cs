using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosSalidaController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public PermisosSalidaController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/PermisosSalida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermisosSalidumDTO>>> GetPermisosSalida()
        {
            return await _context.PermisosSalida
                .Select(x => new PermisosSalidumDTO
                {
                    IdPermisoSalida = x.PermisoId,
                    IdEmpleado = x.EmpleadoId,
                    FechaSolicitud = x.Fecha,
                    HoraSalida = x.HoraSalida,
                    HoraRegreso = x.HoraRegreso,
                    Motivo = x.Motivo,
                    Estado = x.Autorizado ? "Autorizado" : "No Autorizado"
                })
                .ToListAsync();
        }

        // GET: api/PermisosSalida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PermisosSalidumDTO>> GetPermisosSalidum(int id)
        {
            var permisosSalidum = await _context.PermisosSalida.FindAsync(id);

            if (permisosSalidum == null)
            {
                return NotFound();
            }

            return new PermisosSalidumDTO
            {
                IdPermisoSalida = permisosSalidum.PermisoId,
                IdEmpleado = permisosSalidum.EmpleadoId,
                FechaSolicitud = permisosSalidum.Fecha,
                HoraSalida = permisosSalidum.HoraSalida,
                HoraRegreso = permisosSalidum.HoraRegreso,
                Motivo = permisosSalidum.Motivo,
                Estado = permisosSalidum.Autorizado ? "Autorizado" : "No Autorizado"
            };
        }

        // PUT: api/PermisosSalida/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermisosSalidum(int id, PermisosSalidumDTO permisosSalidumDTO)
        {
            if (id != permisosSalidumDTO.IdPermisoSalida)
            {
                return BadRequest();
            }

            var permisosSalidum = await _context.PermisosSalida.FindAsync(id);
            if (permisosSalidum == null)
            {
                return NotFound();
            }

            permisosSalidum.EmpleadoId = permisosSalidumDTO.IdEmpleado;
            permisosSalidum.Fecha = permisosSalidumDTO.FechaSolicitud;
            permisosSalidum.HoraSalida = permisosSalidumDTO.HoraSalida;
            permisosSalidum.HoraRegreso = permisosSalidumDTO.HoraRegreso;
            permisosSalidum.Motivo = permisosSalidumDTO.Motivo;
            permisosSalidum.Autorizado = permisosSalidumDTO.Estado == "Autorizado";

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermisosSalidumExists(id))
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

        // POST: api/PermisosSalida
        [HttpPost]
        public async Task<ActionResult<PermisosSalidumDTO>> PostPermisosSalidum(PermisosSalidumDTO permisosSalidumDTO)
        {
            var permisosSalidum = new PermisosSalidum
            {
                EmpleadoId = permisosSalidumDTO.IdEmpleado,
                Fecha = permisosSalidumDTO.FechaSolicitud,
                HoraSalida = permisosSalidumDTO.HoraSalida,
                HoraRegreso = permisosSalidumDTO.HoraRegreso,
                Motivo = permisosSalidumDTO.Motivo,
                Autorizado = permisosSalidumDTO.Estado == "Autorizado"
            };

            _context.PermisosSalida.Add(permisosSalidum);
            await _context.SaveChangesAsync();

            permisosSalidumDTO.IdPermisoSalida = permisosSalidum.PermisoId; // Update DTO with generated ID

            return CreatedAtAction("GetPermisosSalidum", new { id = permisosSalidumDTO.IdPermisoSalida }, permisosSalidumDTO);
        }

        // DELETE: api/PermisosSalida/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermisosSalidum(int id)
        {
            var permisosSalidum = await _context.PermisosSalida.FindAsync(id);
            if (permisosSalidum == null)
            {
                return NotFound();
            }

            _context.PermisosSalida.Remove(permisosSalidum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PermisosSalidumExists(int id)
        {
            return _context.PermisosSalida.Any(e => e.PermisoId == id);
        }
    }
}