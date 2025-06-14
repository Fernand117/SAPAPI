using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.PermisoSalidas.Commands.CreatePermisoSalida;
using SAP.Application.Features.PermisoSalidas.Commands.UpdatePermisoSalida;
using SAP.Application.Features.PermisoSalidas.Queries.GetPermisoSalidaById;
using SAP.Application.Features.PermisoSalidas.Queries.SearchPermisoSalidas;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisoSalidaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermisoSalidaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetPermisoSalidaByIdQuery { PermisoSalidaId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchPermisoSalidasQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePermisoSalidaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePermisoSalidaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 