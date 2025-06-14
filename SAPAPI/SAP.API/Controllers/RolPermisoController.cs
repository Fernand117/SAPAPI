using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.RolPermisos.Commands.CreateRolPermiso;
using SAP.Application.Features.RolPermisos.Commands.UpdateRolPermiso;
using SAP.Application.Features.RolPermisos.Queries.GetRolPermisoById;
using SAP.Application.Features.RolPermisos.Queries.SearchRolPermisos;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolPermisoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolPermisoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetRolPermisoByIdQuery { RolPermisoId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchRolPermisosQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRolPermisoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRolPermisoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 