using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Asistencias.Commands.UpdateAsistencia
{
    public class UpdateAsistenciaCommand : IRequest<AsistenciaDto>
    {
        public int AsistenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public string Estado { get; set; } = null!;
        public string Observaciones { get; set; } = null!;
    }
} 