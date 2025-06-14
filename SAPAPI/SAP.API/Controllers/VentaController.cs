using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.Ventas.Commands.CreateVenta;
using SAP.Application.Features.Ventas.Queries.GetVentaById;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VentaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetVentaByIdQuery { VentaId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVentaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 