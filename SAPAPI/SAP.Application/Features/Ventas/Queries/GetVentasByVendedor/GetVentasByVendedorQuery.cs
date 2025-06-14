using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Ventas.Queries.GetVentasByVendedor
{
    public class GetVentasByVendedorQuery : IRequest<IEnumerable<VentaDto>>
    {
        public int UsuarioId { get; set; }
    }
} 