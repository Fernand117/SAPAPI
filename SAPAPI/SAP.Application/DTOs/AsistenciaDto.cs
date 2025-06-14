using System;

namespace SAP.Application.DTOs
{
    public class AsistenciaDto
    {
        public int AsistenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public string Estado { get; set; } = null!;
        public string Observaciones { get; set; } = null!;
    }

    public class CreateAsistenciaDto
    {
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
    }

    public class UpdateAsistenciaDto
    {
        public int AsistenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
    }
} 