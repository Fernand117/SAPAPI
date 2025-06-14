using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.CategoriaProductos.Queries.GetCategoriaProductoById
{
    public class GetCategoriaProductoByIdQuery : IRequest<CategoriaProductoDto>
    {
        public int CategoriaProductoId { get; set; }
    }
} 