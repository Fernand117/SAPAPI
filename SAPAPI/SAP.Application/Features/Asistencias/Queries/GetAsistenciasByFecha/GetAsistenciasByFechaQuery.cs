using System;
using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Asistencias.Queries.GetAsistenciasByFecha
{
    public class GetAsistenciasByFechaQuery : IRequest<IEnumerable<AsistenciaDto>>
    {
        public DateTime Fecha { get; set; }
    }
} 