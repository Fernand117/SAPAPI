using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.PermisoSalidas.Commands.CreatePermisoSalida;
namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisoSalidaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermisoSalidaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePermisoSalidaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 