using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.AtributoProductos.Commands.CreateAtributoProducto;
using SAP.Application.Features.AtributoProductos.Commands.UpdateAtributoProducto;
using SAP.Application.Features.AtributoProductos.Queries.GetAtributoProductoById;
using SAP.Application.Features.AtributoProductos.Queries.SearchAtributoProductos;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtributoProductoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AtributoProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetAtributoProductoByIdQuery { AtributoProductoId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchAtributoProductosQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAtributoProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAtributoProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 