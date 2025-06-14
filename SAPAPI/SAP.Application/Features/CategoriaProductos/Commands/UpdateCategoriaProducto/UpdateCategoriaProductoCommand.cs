using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.CategoriaProductos.Commands.UpdateCategoriaProducto
{
    public class UpdateCategoriaProductoCommand : IRequest<CategoriaProductoDto>
    {
        public int CategoriaProductoId { get; set; }
        public int CategoriaId { get; set; }
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? CategoriaPadreId { get; set; }
    }
} 