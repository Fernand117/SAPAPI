using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.Usuarios.Commands.CreateUsuario;
using SAP.Application.Features.Usuarios.Commands.UpdateUsuario;
using SAP.Application.Features.Usuarios.Queries.GetUsuarioById;
using SAP.Application.Features.Usuarios.Queries.SearchUsuarios;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUsuarioByIdQuery { UsuarioId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchUsuariosQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUsuarioCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUsuarioCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 