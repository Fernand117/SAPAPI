using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.InventarioVendedores.Queries.GetInventarioByProducto
{
    public class GetInventarioByProductoQuery : IRequest<IEnumerable<InventarioVendedorDto>>
    {
        public int ProductoId { get; set; }
    }
} 