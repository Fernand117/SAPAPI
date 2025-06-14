using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Categorias.Commands.CreateCategoria
{
    public class CreateCategoriaCommand : IRequest<CategoriaDto>
    {
        public required CreateCategoriaDto Categoria { get; set; }
    }
} 