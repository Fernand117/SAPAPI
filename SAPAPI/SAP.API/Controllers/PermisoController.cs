using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.Permisos.Commands.CreatePermiso;
using SAP.Application.Features.Permisos.Commands.UpdatePermiso;
using SAP.Application.Features.Permisos.Queries.GetPermisoById;
using SAP.Application.Features.Permisos.Queries.SearchPermisos;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermisoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetPermisoByIdQuery { PermisoId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchPermisosQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePermisoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePermisoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 