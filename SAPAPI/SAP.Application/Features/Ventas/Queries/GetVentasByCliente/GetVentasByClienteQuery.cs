using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Ventas.Queries.GetVentasByCliente
{
    public class GetVentasByClienteQuery : IRequest<IEnumerable<VentaDto>>
    {
        public int ClienteId { get; set; }
    }
} 