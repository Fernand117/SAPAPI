using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.UsuarioRoles.Commands.CreateUsuarioRol;
using SAP.Application.Features.UsuarioRoles.Commands.UpdateUsuarioRol;
using SAP.Application.Features.UsuarioRoles.Queries.GetUsuarioRolById;
using SAP.Application.Features.UsuarioRoles.Queries.SearchUsuarioRoles;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioRolController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioRolController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUsuarioRolByIdQuery { UsuarioRolId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchUsuarioRolesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUsuarioRolCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUsuarioRolCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 