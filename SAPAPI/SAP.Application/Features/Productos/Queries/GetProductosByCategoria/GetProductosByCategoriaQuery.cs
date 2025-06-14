using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Productos.Queries.GetProductosByCategoria
{
    public class GetProductosByCategoriaQuery : IRequest<IEnumerable<ProductoDto>>
    {
        public int CategoriaId { get; set; }
    }
} 