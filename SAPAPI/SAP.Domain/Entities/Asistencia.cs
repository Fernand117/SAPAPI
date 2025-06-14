using System;

namespace SAP.Domain.Entities
{
    public class Asistencia
    {
        public int AsistenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }

        // Relaciones
        public Empleado Empleado { get; set; }
    }
} 