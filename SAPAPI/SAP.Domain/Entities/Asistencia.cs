using System;

namespace SAP.Domain.Entities
{
    public class Asistencia
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string Observaciones { get; set; }

        // Relaciones
        public virtual Empleado Empleado { get; set; } = null!;
    }
} 