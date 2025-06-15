using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NominasController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public NominasController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/Nominas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NominaDTO>>> GetNominas()
        {
            return await _context.Nominas
                .Select(n => new NominaDTO
                {
                    NominaId = n.NominaId,
                    EmpleadoId = n.EmpleadoId,
                    FechaInicio = n.FechaInicio,
                    FechaFin = n.FechaFin,
                    SueldoBase = n.SueldoBase,
                    Bonos = n.Bonos,
                    Deducciones = n.Deducciones,
                    TotalPagar = n.TotalPagar,
                    FechaPago = n.FechaPago,
                    Estado = n.Estado
                })
                .ToListAsync();
        }

        // GET: api/Nominas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NominaDTO>> GetNomina(int id)
        {
            var nomina = await _context.Nominas.FindAsync(id);

            if (nomina == null)
            {
                return NotFound();
            }

            return new NominaDTO
            {
                NominaId = nomina.NominaId,
                EmpleadoId = nomina.EmpleadoId,
                FechaInicio = nomina.FechaInicio,
                FechaFin = nomina.FechaFin,
                SueldoBase = nomina.SueldoBase,
                Bonos = nomina.Bonos,
                Deducciones = nomina.Deducciones,
                TotalPagar = nomina.TotalPagar,
                FechaPago = nomina.FechaPago,
                Estado = nomina.Estado
            };
        }

        // PUT: api/Nominas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNomina(int id, NominaDTO nominaDTO)
        {
            if (id != nominaDTO.NominaId)
            {
                return BadRequest();
            }

            var nomina = await _context.Nominas.FindAsync(id);
            if (nomina == null)
            {
                return NotFound();
            }

            nomina.EmpleadoId = nominaDTO.EmpleadoId;
            nomina.FechaInicio = nominaDTO.FechaInicio;
            nomina.FechaFin = nominaDTO.FechaFin;
            nomina.SueldoBase = nominaDTO.SueldoBase;
            nomina.Bonos = nominaDTO.Bonos;
            nomina.Deducciones = nominaDTO.Deducciones;
            nomina.TotalPagar = nominaDTO.TotalPagar;
            nomina.FechaPago = nominaDTO.FechaPago;
            nomina.Estado = nominaDTO.Estado;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NominaExists(id))
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

        // POST: api/Nominas
        [HttpPost]
        public async Task<ActionResult<NominaDTO>> PostNomina(NominaDTO nominaDTO)
        {
            var nomina = new Nomina
            {
                EmpleadoId = nominaDTO.EmpleadoId,
                FechaInicio = nominaDTO.FechaInicio,
                FechaFin = nominaDTO.FechaFin,
                SueldoBase = nominaDTO.SueldoBase,
                Bonos = nominaDTO.Bonos,
                Deducciones = nominaDTO.Deducciones,
                TotalPagar = nominaDTO.TotalPagar,
                FechaPago = nominaDTO.FechaPago,
                Estado = nominaDTO.Estado
            };

            _context.Nominas.Add(nomina);
            await _context.SaveChangesAsync();

            nominaDTO.NominaId = nomina.NominaId; // Update DTO with generated ID

            return CreatedAtAction("GetNomina", new { id = nomina.NominaId }, nominaDTO);
        }

        // DELETE: api/Nominas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNomina(int id)
        {
            var nomina = await _context.Nominas.FindAsync(id);
            if (nomina == null)
            {
                return NotFound();
            }

            _context.Nominas.Remove(nomina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NominaExists(int id)
        {
            return _context.Nominas.Any(e => e.NominaId == id);
        }
    }
}