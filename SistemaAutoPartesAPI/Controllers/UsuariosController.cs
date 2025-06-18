using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;
using SistemaAutoPartesAPI.Utils;

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
            // Generar una contraseña por defecto y hashearla
            var defaultPassword = Guid.NewGuid().ToString().Substring(0, 8); // Contraseña aleatoria de 8 caracteres
            var passwordHash = PasswordHasher.HashPassword(defaultPassword);

            var usuario = new Usuario
            {
                EmpleadoId = usuarioDTO.EmpleadoId,
                Username = usuarioDTO.Username,
                PasswordHash = passwordHash, // Guardar el hash de la contraseña
                Activo = usuarioDTO.Activo
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            usuarioDTO.UsuarioId = usuario.UsuarioId; // Actualizar DTO con el ID generado

            // Opcional: Devolver la contraseña por defecto para que el usuario la conozca y la cambie
            // En un entorno real, esto se enviaría por correo electrónico o un canal seguro.
            // Por simplicidad, aquí solo se devuelve en la respuesta (NO RECOMENDADO EN PRODUCCIÓN).
            // usuarioDTO.PasswordHash = defaultPassword; // No se debe exponer el hash ni la contraseña en el DTO

            return CreatedAtAction("GetUsuario", new { id = usuario.UsuarioId }, usuarioDTO);
        }

        // POST: api/Usuarios/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Username == request.Username && u.PasswordHash == request.Password);

            if (usuario == null || !PasswordHasher.VerifyPassword(request.Password, usuario.PasswordHash))
            {
                return Unauthorized("Credenciales inválidas.");
            }

            // En un escenario real, aquí se generaría un token JWT
            return Ok(new ApiResponse(200, "Usuario autentificado", usuario));
        }

        // PUT: api/Usuarios/change-password
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Username == request.Username);

            if (usuario == null || !PasswordHasher.VerifyPassword(request.OldPassword, usuario.PasswordHash))
            {
                return Unauthorized("Credenciales inválidas o contraseña antigua incorrecta.");
            }

            // Actualizar la contraseña
            usuario.PasswordHash = PasswordHasher.HashPassword(request.NewPassword);
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new ApiResponse(200, "Contraseña actualizada correctamente.", usuario));
            }
            catch (DbUpdateConcurrencyException)
            {
                // Esto podría ocurrir si el usuario se elimina o modifica concurrentemente
                return NotFound(new ApiResponse(404, "No se encontró al usuario"));
            }
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