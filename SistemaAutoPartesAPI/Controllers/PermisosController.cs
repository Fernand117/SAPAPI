using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public PermisosController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/Permisos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermisoDTO>>> GetPermisos()
        {
            return await _context.Permisos
                .Select(p => new PermisoDTO
                {
                    PermisoId = p.PermisoId,
                    Nombre = p.Nombre,
                    Modulo = p.Modulo,
                    Descripcion = p.Descripcion
                })
                .ToListAsync();
        }

        // GET: api/Permisos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PermisoDTO>> GetPermiso(int id)
        {
            var permiso = await _context.Permisos.FindAsync(id);

            if (permiso == null)
            {
                return NotFound();
            }

            return new PermisoDTO
            {
                PermisoId = permiso.PermisoId,
                Nombre = permiso.Nombre,
                Modulo = permiso.Modulo,
                Descripcion = permiso.Descripcion
            };
        }

        // PUT: api/Permisos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermiso(int id, PermisoDTO permisoDTO)
        {
            if (id != permisoDTO.PermisoId)
            {
                return BadRequest();
            }

            var permiso = await _context.Permisos.FindAsync(id);
            if (permiso == null)
            {
                return NotFound();
            }

            permiso.Nombre = permisoDTO.Nombre;
            permiso.Modulo = permisoDTO.Modulo;
            permiso.Descripcion = permisoDTO.Descripcion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermisoExists(id))
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

        // POST: api/Permisos
        [HttpPost]
        public async Task<ActionResult<PermisoDTO>> PostPermiso(PermisoDTO permisoDTO)
        {
            var permiso = new Permiso
            {
                Nombre = permisoDTO.Nombre,
                Modulo = permisoDTO.Modulo,
                Descripcion = permisoDTO.Descripcion
            };

            _context.Permisos.Add(permiso);
            await _context.SaveChangesAsync();

            permisoDTO.PermisoId = permiso.PermisoId; // Update DTO with generated ID

            return CreatedAtAction("GetPermiso", new { id = permiso.PermisoId }, permisoDTO);
        }

        // DELETE: api/Permisos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermiso(int id)
        {
            var permiso = await _context.Permisos.FindAsync(id);
            if (permiso == null)
            {
                return NotFound();
            }

            _context.Permisos.Remove(permiso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PermisoExists(int id)
        {
            return _context.Permisos.Any(e => e.PermisoId == id);
        }
    }
}