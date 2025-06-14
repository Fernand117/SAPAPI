using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Ventas.Queries.GetVentasBySucursal
{
    public class GetVentasBySucursalQuery : IRequest<IEnumerable<VentaDto>>
    {
        public int SucursalId { get; set; }
    }
} 