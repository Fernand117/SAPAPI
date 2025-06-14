using System;
using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Ventas.Queries.GetVentasByFecha
{
    public class GetVentasByFechaQuery : IRequest<IEnumerable<VentaDto>>
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
} 