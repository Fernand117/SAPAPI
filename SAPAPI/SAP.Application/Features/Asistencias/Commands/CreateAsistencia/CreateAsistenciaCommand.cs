using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Asistencias.Commands.CreateAsistencia
{
    public class CreateAsistenciaCommand : IRequest<AsistenciaDto>
    {
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
    }
} 