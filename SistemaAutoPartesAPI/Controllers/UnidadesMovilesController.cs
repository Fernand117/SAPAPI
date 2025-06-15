using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesMovilesController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public UnidadesMovilesController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/UnidadesMoviles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadesMovileDTO>>> GetUnidadesMoviles()
        {
            return await _context.UnidadesMoviles
                .Select(x => new UnidadesMovileDTO
                {
                    UnidadId = x.UnidadId,
                    SucursalId = x.SucursalId,
                    Tipo = x.Tipo,
                    Marca = x.Marca,
                    Modelo = x.Modelo,
                    Placa = x.Placa,
                    Activa = x.Activa
                })
                .ToListAsync();
        }

        // GET: api/UnidadesMoviles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadesMovileDTO>> GetUnidadesMovile(int id)
        {
            var unidadesMovile = await _context.UnidadesMoviles.FindAsync(id);

            if (unidadesMovile == null)
            {
                return NotFound();
            }

            return new UnidadesMovileDTO
            {
                UnidadId = unidadesMovile.UnidadId,
                SucursalId = unidadesMovile.SucursalId,
                Tipo = unidadesMovile.Tipo,
                Marca = unidadesMovile.Marca,
                Modelo = unidadesMovile.Modelo,
                Placa = unidadesMovile.Placa,
                Activa = unidadesMovile.Activa
            };
        }

        // PUT: api/UnidadesMoviles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadesMovile(int id, UnidadesMovileDTO unidadesMovileDTO)
        {
            if (id != unidadesMovileDTO.UnidadId)
            {
                return BadRequest();
            }

            var unidadesMovile = await _context.UnidadesMoviles.FindAsync(id);
            if (unidadesMovile == null)
            {
                return NotFound();
            }

            unidadesMovile.SucursalId = unidadesMovileDTO.SucursalId;
            unidadesMovile.Tipo = unidadesMovileDTO.Tipo;
            unidadesMovile.Marca = unidadesMovileDTO.Marca;
            unidadesMovile.Modelo = unidadesMovileDTO.Modelo;
            unidadesMovile.Placa = unidadesMovileDTO.Placa;
            unidadesMovile.Activa = unidadesMovileDTO.Activa;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadesMovileExists(id))
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

        // POST: api/UnidadesMoviles
        [HttpPost]
        public async Task<ActionResult<UnidadesMovileDTO>> PostUnidadesMovile(UnidadesMovileDTO unidadesMovileDTO)
        {
            var unidadesMovile = new UnidadesMovile
            {
                SucursalId = unidadesMovileDTO.SucursalId,
                Tipo = unidadesMovileDTO.Tipo,
                Marca = unidadesMovileDTO.Marca,
                Modelo = unidadesMovileDTO.Modelo,
                Placa = unidadesMovileDTO.Placa,
                Activa = unidadesMovileDTO.Activa
            };

            _context.UnidadesMoviles.Add(unidadesMovile);
            await _context.SaveChangesAsync();

            unidadesMovileDTO.UnidadId = unidadesMovile.UnidadId; // Update DTO with generated ID

            return CreatedAtAction("GetUnidadesMovile", new { id = unidadesMovileDTO.UnidadId }, unidadesMovileDTO);
        }

        // DELETE: api/UnidadesMoviles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidadesMovile(int id)
        {
            var unidadesMovile = await _context.UnidadesMoviles.FindAsync(id);
            if (unidadesMovile == null)
            {
                return NotFound();
            }

            _context.UnidadesMoviles.Remove(unidadesMovile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnidadesMovileExists(int id)
        {
            return _context.UnidadesMoviles.Any(e => e.UnidadId == id);
        }
    }
}