using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolPermisoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolPermisoController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
} 