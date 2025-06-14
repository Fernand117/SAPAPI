using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.DetalleVentas.Commands.CreateDetalleVenta;
using SAP.Application.Features.DetalleVentas.Commands.UpdateDetalleVenta;
using SAP.Application.Features.DetalleVentas.Queries.GetDetalleVentaById;
using SAP.Application.Features.DetalleVentas.Queries.SearchDetalleVentas;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleVentaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DetalleVentaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetDetalleVentaByIdQuery { DetalleVentaId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchDetalleVentasQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDetalleVentaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDetalleVentaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 