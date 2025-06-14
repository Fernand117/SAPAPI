using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.ProductoAtributos.Commands.CreateProductoAtributo;
using SAP.Application.Features.ProductoAtributos.Commands.UpdateProductoAtributo;
using SAP.Application.Features.ProductoAtributos.Queries.GetProductoAtributoById;
using SAP.Application.Features.ProductoAtributos.Queries.SearchProductoAtributos;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoAtributoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductoAtributoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProductoAtributoByIdQuery { ProductoAtributoId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchProductoAtributosQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductoAtributoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductoAtributoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 