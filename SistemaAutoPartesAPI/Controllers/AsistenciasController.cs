using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciasController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public AsistenciasController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/Asistencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsistenciaDTO>>> GetAsistencias()
        {
            return await _context.Asistencias
                .Select(a => new AsistenciaDTO
                {
                    AsistenciaId = a.AsistenciaId,
                    EmpleadoId = a.EmpleadoId,
                    Fecha = a.Fecha,
                    HoraEntrada = a.HoraEntrada,
                    HoraSalida = a.HoraSalida,
                    Observaciones = a.Observaciones
                })
                .ToListAsync();
        }

        // GET: api/Asistencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsistenciaDTO>> GetAsistencia(int id)
        {
            var asistencia = await _context.Asistencias.FindAsync(id);

            if (asistencia == null)
            {
                return NotFound();
            }

            return new AsistenciaDTO
            {
                AsistenciaId = asistencia.AsistenciaId,
                EmpleadoId = asistencia.EmpleadoId,
                Fecha = asistencia.Fecha,
                HoraEntrada = asistencia.HoraEntrada,
                HoraSalida = asistencia.HoraSalida,
                Observaciones = asistencia.Observaciones
            };
        }

        // PUT: api/Asistencias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsistencia(int id, AsistenciaDTO asistenciaDTO)
        {
            if (id != asistenciaDTO.AsistenciaId)
            {
                return BadRequest();
            }

            var asistencia = await _context.Asistencias.FindAsync(id);
            if (asistencia == null)
            {
                return NotFound();
            }

            asistencia.EmpleadoId = asistenciaDTO.EmpleadoId;
            asistencia.Fecha = asistenciaDTO.Fecha;
            asistencia.HoraEntrada = asistenciaDTO.HoraEntrada;
            asistencia.HoraSalida = asistenciaDTO.HoraSalida;
            asistencia.Observaciones = asistenciaDTO.Observaciones;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsistenciaExists(id))
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

        // POST: api/Asistencias
        [HttpPost]
        public async Task<ActionResult<AsistenciaDTO>> PostAsistencia(AsistenciaDTO asistenciaDTO)
        {
            var asistencia = new Asistencia
            {
                EmpleadoId = asistenciaDTO.EmpleadoId,
                Fecha = asistenciaDTO.Fecha,
                HoraEntrada = asistenciaDTO.HoraEntrada,
                HoraSalida = asistenciaDTO.HoraSalida,
                Observaciones = asistenciaDTO.Observaciones
            };

            _context.Asistencias.Add(asistencia);
            await _context.SaveChangesAsync();

            asistenciaDTO.AsistenciaId = asistencia.AsistenciaId; // Update DTO with generated ID

            return CreatedAtAction("GetAsistencia", new { id = asistencia.AsistenciaId }, asistenciaDTO);
        }

        // DELETE: api/Asistencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsistencia(int id)
        {
            var asistencia = await _context.Asistencias.FindAsync(id);
            if (asistencia == null)
            {
                return NotFound();
            }

            _context.Asistencias.Remove(asistencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsistenciaExists(int id)
        {
            return _context.Asistencias.Any(e => e.AsistenciaId == id);
        }
    }
}