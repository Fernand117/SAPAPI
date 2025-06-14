using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.Inventarios.Commands.CreateInventario;
using SAP.Application.Features.Inventarios.Commands.UpdateInventario;
using SAP.Application.Features.Inventarios.Queries.GetInventarioById;
using SAP.Application.Features.Inventarios.Queries.SearchInventarios;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetInventarioByIdQuery { InventarioId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchInventariosQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInventarioCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateInventarioCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 