using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.ProductoAtributos.Commands.UpdateProductoAtributo
{
    public class UpdateProductoAtributoCommand : IRequest<ProductoAtributoDto>
    {
        public int ProductoAtributoId { get; set; }
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }
    }
} 