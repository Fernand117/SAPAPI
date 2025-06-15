using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public UsuariosController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios
                .Select(u => new UsuarioDTO
                {
                    UsuarioId = u.UsuarioId,
                    EmpleadoId = u.EmpleadoId,
                    Username = u.Username,
                    Activo = u.Activo
                })
                .ToListAsync();

            return Ok(usuarios);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioDTO = new UsuarioDTO
            {
                UsuarioId = usuario.UsuarioId,
                EmpleadoId = usuario.EmpleadoId,
                Username = usuario.Username,
                Activo = usuario.Activo
            };

            return Ok(usuarioDTO);
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> PostUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                EmpleadoId = usuarioDTO.EmpleadoId,
                Username = usuarioDTO.Username,
                // PasswordHash should be handled securely, not directly from DTO
                Activo = usuarioDTO.Activo
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            usuarioDTO.UsuarioId = usuario.UsuarioId; // Update DTO with generated ID

            return CreatedAtAction("GetUsuario", new { id = usuario.UsuarioId }, usuarioDTO);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioDTO usuarioDTO)
        {
            if (id != usuarioDTO.UsuarioId)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.EmpleadoId = usuarioDTO.EmpleadoId;
            usuario.Username = usuarioDTO.Username;
            usuario.Activo = usuarioDTO.Activo;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioId == id);
        }
    }
}