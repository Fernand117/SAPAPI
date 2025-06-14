using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.Asistencias.Commands.CreateAsistencia;
using SAP.Application.Features.Asistencias.Commands.UpdateAsistencia;
using SAP.Application.Features.Asistencias.Queries.GetAsistenciaById;
using SAP.Application.Features.Asistencias.Queries.SearchAsistencias;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsistenciaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AsistenciaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetAsistenciaByIdQuery { AsistenciaId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchAsistenciasQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAsistenciaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAsistenciaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 