using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP.Application.Features.Categorias.Commands.CreateCategoria;
using SAP.Application.Features.Categorias.Commands.UpdateCategoria;
using SAP.Application.Features.Categorias.Queries.GetCategoriaById;
using SAP.Application.Features.Categorias.Queries.SearchCategorias;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCategoriaByIdQuery { CategoriaId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchCategoriasQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoriaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoriaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 