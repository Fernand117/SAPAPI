using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public ClientesController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
        {
            return await _context.Clientes
                .Select(c => new ClienteDTO
                {
                    ClienteId = c.ClienteId,
                    Nombre = c.Nombre,
                    Rfc = c.Rfc,
                    Direccion = c.Direccion,
                    Telefono = c.Telefono,
                    Email = c.Email,
                    SucursalId = c.SucursalId
                })
                .ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return new ClienteDTO
            {
                ClienteId = cliente.ClienteId,
                Nombre = cliente.Nombre,
                Rfc = cliente.Rfc,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Email = cliente.Email,
                SucursalId = cliente.SucursalId
            };
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteDTO clienteDTO)
        {
            if (id != clienteDTO.ClienteId)
            {
                return BadRequest();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Nombre = clienteDTO.Nombre;
            cliente.Rfc = clienteDTO.Rfc;
            cliente.Direccion = clienteDTO.Direccion;
            cliente.Telefono = clienteDTO.Telefono;
            cliente.Email = clienteDTO.Email;
            cliente.SucursalId = clienteDTO.SucursalId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> PostCliente(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente
            {
                Nombre = clienteDTO.Nombre,
                Rfc = clienteDTO.Rfc,
                Direccion = clienteDTO.Direccion,
                Telefono = clienteDTO.Telefono,
                Email = clienteDTO.Email,
                SucursalId = clienteDTO.SucursalId
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            clienteDTO.ClienteId = cliente.ClienteId; // Update DTO with generated ID

            return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, clienteDTO);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.ClienteId == id);
        }
    }
}