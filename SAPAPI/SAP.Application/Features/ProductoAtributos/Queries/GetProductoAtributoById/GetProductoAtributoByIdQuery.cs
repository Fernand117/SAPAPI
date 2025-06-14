using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.ProductoAtributos.Queries.GetProductoAtributoById
{
    public class GetProductoAtributoByIdQuery : IRequest<ProductoAtributoDto>
    {
        public int ProductoAtributoId { get; set; }
    }
} 