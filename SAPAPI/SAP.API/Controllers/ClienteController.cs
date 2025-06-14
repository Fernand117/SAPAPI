using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.Clientes.Commands.CreateCliente;
using SAP.Application.Features.Clientes.Commands.UpdateCliente;
using SAP.Application.Features.Clientes.Queries.GetClienteById;
using SAP.Application.Features.Clientes.Queries.SearchClientes;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetClienteByIdQuery { ClienteId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchClientesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClienteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateClienteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 