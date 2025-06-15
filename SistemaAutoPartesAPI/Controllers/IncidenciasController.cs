using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenciasController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public IncidenciasController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/Incidencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidenciaDTO>>> GetIncidencias()
        {
            return await _context.Incidencias
                .Select(i => new IncidenciaDTO
                {
                    IncidenciaId = i.IncidenciaId,
                    EmpleadoId = i.EmpleadoId,
                    Fecha = i.Fecha,
                    Tipo = i.Tipo,
                    Descripcion = i.Descripcion,
                    Justificada = i.Justificada
                })
                .ToListAsync();
        }

        // GET: api/Incidencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidenciaDTO>> GetIncidencia(int id)
        {
            var incidencia = await _context.Incidencias.FindAsync(id);

            if (incidencia == null)
            {
                return NotFound();
            }

            return new IncidenciaDTO
            {
                IncidenciaId = incidencia.IncidenciaId,
                EmpleadoId = incidencia.EmpleadoId,
                Fecha = incidencia.Fecha,
                Tipo = incidencia.Tipo,
                Descripcion = incidencia.Descripcion,
                Justificada = incidencia.Justificada
            };
        }

        // PUT: api/Incidencias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidencia(int id, IncidenciaDTO incidenciaDTO)
        {
            if (id != incidenciaDTO.IncidenciaId)
            {
                return BadRequest();
            }

            var incidencia = await _context.Incidencias.FindAsync(id);
            if (incidencia == null)
            {
                return NotFound();
            }

            incidencia.EmpleadoId = incidenciaDTO.EmpleadoId;
            incidencia.Fecha = incidenciaDTO.Fecha;
            incidencia.Tipo = incidenciaDTO.Tipo;
            incidencia.Descripcion = incidenciaDTO.Descripcion;
            incidencia.Justificada = incidenciaDTO.Justificada;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidenciaExists(id))
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

        // POST: api/Incidencias
        [HttpPost]
        public async Task<ActionResult<IncidenciaDTO>> PostIncidencia(IncidenciaDTO incidenciaDTO)
        {
            var incidencia = new Incidencia
            {
                EmpleadoId = incidenciaDTO.EmpleadoId,
                Fecha = incidenciaDTO.Fecha,
                Tipo = incidenciaDTO.Tipo,
                Descripcion = incidenciaDTO.Descripcion,
                Justificada = incidenciaDTO.Justificada
            };

            _context.Incidencias.Add(incidencia);
            await _context.SaveChangesAsync();

            incidenciaDTO.IncidenciaId = incidencia.IncidenciaId; // Update DTO with generated ID

            return CreatedAtAction("GetIncidencia", new { id = incidencia.IncidenciaId }, incidenciaDTO);
        }

        // DELETE: api/Incidencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidencia(int id)
        {
            var incidencia = await _context.Incidencias.FindAsync(id);
            if (incidencia == null)
            {
                return NotFound();
            }

            _context.Incidencias.Remove(incidencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncidenciaExists(int id)
        {
            return _context.Incidencias.Any(e => e.IncidenciaId == id);
        }
    }
}