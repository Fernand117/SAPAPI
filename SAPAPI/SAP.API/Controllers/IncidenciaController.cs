using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.Incidencias.Commands.CreateIncidencia;
using SAP.Application.Features.Incidencias.Commands.UpdateIncidencia;
using SAP.Application.Features.Incidencias.Queries.GetIncidenciaById;
using SAP.Application.Features.Incidencias.Queries.SearchIncidencias;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidenciaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IncidenciaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetIncidenciaByIdQuery { IncidenciaId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchIncidenciasQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIncidenciaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateIncidenciaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 