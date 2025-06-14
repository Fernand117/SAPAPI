using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.Empleados.Commands.CreateEmpleado;
using SAP.Application.Features.Empleados.Commands.UpdateEmpleado;
using SAP.Application.Features.Empleados.Queries.GetEmpleadoById;
using SAP.Application.Features.Empleados.Queries.SearchEmpleados;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmpleadoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetEmpleadoByIdQuery { EmpleadoId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchEmpleadosQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmpleadoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEmpleadoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 