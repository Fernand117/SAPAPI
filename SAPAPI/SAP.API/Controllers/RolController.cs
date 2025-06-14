using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.Roles.Commands.CreateRol;
using SAP.Application.Features.Roles.Commands.UpdateRol;
using SAP.Application.Features.Roles.Queries.GetRolById;
using SAP.Application.Features.Roles.Queries.SearchRoles;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetRolByIdQuery { RolId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchRolesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRolCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRolCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 