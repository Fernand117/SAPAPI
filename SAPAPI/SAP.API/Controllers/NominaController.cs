using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.Nominas.Commands.CreateNomina;
using SAP.Application.Features.Nominas.Commands.UpdateNomina;
using SAP.Application.Features.Nominas.Queries.SearchNominas;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NominaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NominaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchNominasQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNominaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNominaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 