using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
} 