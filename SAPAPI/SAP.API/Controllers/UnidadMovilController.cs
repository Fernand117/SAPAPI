using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.UnidadMoviles.Commands.CreateUnidadMovil;
using SAP.Application.Features.UnidadMoviles.Commands.UpdateUnidadMovil;
using SAP.Application.Features.UnidadMoviles.Queries.GetUnidadMovilById;
using SAP.Application.Features.UnidadMoviles.Queries.SearchUnidadMoviles;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnidadMovilController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UnidadMovilController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUnidadMovilByIdQuery { UnidadMovilId = id };
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string searchTerm, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new SearchUnidadMovilesQuery
            {
                SearchTerm = searchTerm,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUnidadMovilCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.UnidadMovilId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUnidadMovilCommand command)
        {
            if (id != command.UnidadMovilId)
                return BadRequest();

            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : NotFound();
        }
    }
} 