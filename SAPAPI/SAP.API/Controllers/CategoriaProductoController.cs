using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.CategoriaProductos.Commands.CreateCategoriaProducto;
using SAP.Application.Features.CategoriaProductos.Commands.UpdateCategoriaProducto;
using SAP.Application.Features.CategoriaProductos.Queries.GetCategoriaProductoById;
using SAP.Application.Features.CategoriaProductos.Queries.SearchCategoriaProductos;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaProductoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriaProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCategoriaProductoByIdQuery { CategoriaProductoId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchCategoriaProductosQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoriaProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoriaProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 