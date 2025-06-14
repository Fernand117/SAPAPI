using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.ProductoAtributos.Commands.CreateProductoAtributo
{
    public class CreateProductoAtributoCommand : IRequest<ProductoAtributoDto>
    {
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }
    }
} 