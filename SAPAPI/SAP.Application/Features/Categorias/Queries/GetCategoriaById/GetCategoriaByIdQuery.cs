using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Categorias.Queries.GetCategoriaById
{
    public class GetCategoriaByIdQuery : IRequest<CategoriaDto>
    {
        public int CategoriaId { get; set; }
    }
} 