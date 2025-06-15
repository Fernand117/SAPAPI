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
    public class RolesController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public RolesController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles()
        {
            return await _context.Roles
                .Select(x => new RoleDTO
                {
                    RolId = x.RolId,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion
                })
                .ToListAsync();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return new RoleDTO
            {
                RolId = role.RolId,
                Nombre = role.Nombre,
                Descripcion = role.Descripcion
            };
        }

        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, RoleDTO roleDTO)
        {
            if (id != roleDTO.RolId)
            {
                return BadRequest();
            }

            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            role.Nombre = roleDTO.Nombre;
            role.Descripcion = roleDTO.Descripcion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult<RoleDTO>> PostRole(RoleDTO roleDTO)
        {
            var role = new Role
            {
                Nombre = roleDTO.Nombre,
                Descripcion = roleDTO.Descripcion
            };

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            roleDTO.RolId = role.RolId; // Update DTO with generated ID

            return CreatedAtAction("GetRole", new { id = roleDTO.RolId }, roleDTO);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(int id)
        {
            return _context.Roles.Any(e => e.RolId == id);
        }
    }
}