using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.Sucursales.Commands.CreateSucursal;
using SAP.Application.Features.Sucursales.Commands.UpdateSucursal;
using SAP.Application.Features.Sucursales.Queries.GetSucursalById;
using SAP.Application.Features.Sucursales.Queries.SearchSucursales;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SucursalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SucursalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetSucursalByIdQuery { SucursalId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchSucursalesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSucursalCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSucursalCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 