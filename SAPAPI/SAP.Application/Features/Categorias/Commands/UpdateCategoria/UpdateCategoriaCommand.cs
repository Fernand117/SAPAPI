using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Categorias.Commands.UpdateCategoria
{
    public class UpdateCategoriaCommand : IRequest<CategoriaDto>
    {
        public required UpdateCategoriaDto Categoria { get; set; }
    }
} 