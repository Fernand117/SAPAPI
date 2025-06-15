using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public EmpleadosController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoDTO>>> GetEmpleados()
        {
            var empleados = await _context.Empleados
                .Select(e => new EmpleadoDTO
                {
                    EmpleadoId = e.EmpleadoId,
                    Nombre = e.Nombre,
                    ApellidoPaterno = e.ApellidoPaterno,
                    ApellidoMaterno = e.ApellidoMaterno,
                    FechaNacimiento = e.FechaNacimiento,
                    Genero = e.Genero,
                    Curp = e.Curp,
                    Rfc = e.Rfc,
                    Nss = e.Nss,
                    Direccion = e.Direccion,
                    Telefono = e.Telefono,
                    Email = e.Email,
                    FechaIngreso = e.FechaIngreso,
                    Activo = e.Activo,
                    SucursalId = e.SucursalId,
                    FotoUrl = e.FotoUrl
                })
                .ToListAsync();

            return Ok(empleados);
        }

        // GET: api/Empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoDTO>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            var empleadoDTO = new EmpleadoDTO
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                ApellidoPaterno = empleado.ApellidoPaterno,
                ApellidoMaterno = empleado.ApellidoMaterno,
                FechaNacimiento = empleado.FechaNacimiento,
                Genero = empleado.Genero,
                Curp = empleado.Curp,
                Rfc = empleado.Rfc,
                Nss = empleado.Nss,
                Direccion = empleado.Direccion,
                Telefono = empleado.Telefono,
                Email = empleado.Email,
                FechaIngreso = empleado.FechaIngreso,
                Activo = empleado.Activo,
                SucursalId = empleado.SucursalId,
                FotoUrl = empleado.FotoUrl
            };

            return Ok(empleadoDTO);
        }

        // POST: api/Empleados
        [HttpPost]
        public async Task<ActionResult<EmpleadoDTO>> PostEmpleado(EmpleadoDTO empleadoDTO)
        {
            var empleado = new Empleado
            {
                Nombre = empleadoDTO.Nombre,
                ApellidoPaterno = empleadoDTO.ApellidoPaterno,
                ApellidoMaterno = empleadoDTO.ApellidoMaterno,
                FechaNacimiento = empleadoDTO.FechaNacimiento,
                Genero = empleadoDTO.Genero,
                Curp = empleadoDTO.Curp,
                Rfc = empleadoDTO.Rfc,
                Nss = empleadoDTO.Nss,
                Direccion = empleadoDTO.Direccion,
                Telefono = empleadoDTO.Telefono,
                Email = empleadoDTO.Email,
                FechaIngreso = empleadoDTO.FechaIngreso,
                Activo = empleadoDTO.Activo,
                SucursalId = empleadoDTO.SucursalId,
                FotoUrl = empleadoDTO.FotoUrl
            };

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            empleadoDTO.EmpleadoId = empleado.EmpleadoId; // Update DTO with generated ID

            return CreatedAtAction("GetEmpleado", new { id = empleado.EmpleadoId }, empleadoDTO);
        }

        // PUT: api/Empleados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, EmpleadoDTO empleadoDTO)
        {
            if (id != empleadoDTO.EmpleadoId)
            {
                return BadRequest();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            empleado.Nombre = empleadoDTO.Nombre;
            empleado.ApellidoPaterno = empleadoDTO.ApellidoPaterno;
            empleado.ApellidoMaterno = empleadoDTO.ApellidoMaterno;
            empleado.FechaNacimiento = empleadoDTO.FechaNacimiento;
            empleado.Genero = empleadoDTO.Genero;
            empleado.Curp = empleadoDTO.Curp;
            empleado.Rfc = empleadoDTO.Rfc;
            empleado.Nss = empleadoDTO.Nss;
            empleado.Direccion = empleadoDTO.Direccion;
            empleado.Telefono = empleadoDTO.Telefono;
            empleado.Email = empleadoDTO.Email;
            empleado.FechaIngreso = empleadoDTO.FechaIngreso;
            empleado.Activo = empleadoDTO.Activo;
            empleado.SucursalId = empleadoDTO.SucursalId;
            empleado.FotoUrl = empleadoDTO.FotoUrl;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.EmpleadoId == id);
        }
    }
}