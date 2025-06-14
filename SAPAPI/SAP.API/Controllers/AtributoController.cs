using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.Atributos.Commands.CreateAtributo;
using SAP.Application.Features.Atributos.Commands.UpdateAtributo;
using SAP.Application.Features.Atributos.Queries.GetAtributoById;
using SAP.Application.Features.Atributos.Queries.SearchAtributos;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtributoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AtributoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetAtributoByIdQuery { AtributoId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchAtributosQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAtributoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAtributoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 