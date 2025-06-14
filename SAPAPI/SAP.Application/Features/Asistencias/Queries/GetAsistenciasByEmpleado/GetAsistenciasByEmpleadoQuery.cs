using System;
using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Asistencias.Queries.GetAsistenciasByEmpleado
{
    public class GetAsistenciasByEmpleadoQuery : IRequest<IEnumerable<AsistenciaDto>>
    {
        public int EmpleadoId { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.MinValue;
        public DateTime FechaFin { get; set; } = DateTime.MaxValue;
    }
} 