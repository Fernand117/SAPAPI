using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.UsuarioUnidades.Commands.CreateUsuarioUnidad;
using SAP.Application.Features.UsuarioUnidades.Commands.UpdateUsuarioUnidad;
using SAP.Application.Features.UsuarioUnidades.Queries.GetUsuarioUnidadById;
using SAP.Application.Features.UsuarioUnidades.Queries.SearchUsuarioUnidades;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioUnidadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioUnidadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUsuarioUnidadByIdQuery { UsuarioUnidadId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchUsuarioUnidadesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUsuarioUnidadCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUsuarioUnidadCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 