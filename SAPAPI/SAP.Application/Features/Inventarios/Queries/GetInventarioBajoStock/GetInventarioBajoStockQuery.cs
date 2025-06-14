using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Inventarios.Queries.GetInventarioBajoStock
{
    public class GetInventarioBajoStockQuery : IRequest<IEnumerable<InventarioDto>>
    {
        public int CantidadMinima { get; set; }
    }
} 