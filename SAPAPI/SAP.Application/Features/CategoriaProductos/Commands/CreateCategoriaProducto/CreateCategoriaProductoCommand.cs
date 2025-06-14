using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.CategoriaProductos.Commands.CreateCategoriaProducto
{
    public class CreateCategoriaProductoCommand : IRequest<CategoriaProductoDto>
    {
        public int CategoriaId { get; set; }
        public int ProductoId { get; set; }
    }
} 