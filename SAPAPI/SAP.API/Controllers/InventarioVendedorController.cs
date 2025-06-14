using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.InventarioVendedores.Commands.CreateInventarioVendedor;
using SAP.Application.Features.InventarioVendedores.Commands.UpdateInventarioVendedor;
using SAP.Application.Features.InventarioVendedores.Queries.GetInventarioVendedorById;
using SAP.Application.Features.InventarioVendedores.Queries.SearchInventarioVendedores;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioVendedorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventarioVendedorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetInventarioVendedorByIdQuery { InventarioVendedorId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchInventarioVendedoresQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInventarioVendedorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateInventarioVendedorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 