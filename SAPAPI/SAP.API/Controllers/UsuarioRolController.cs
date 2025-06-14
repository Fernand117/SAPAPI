using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioRolController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioRolController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
} 