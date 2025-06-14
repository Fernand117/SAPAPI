using System;

namespace SAP.Domain.Entities
{
    public class Asistencia
    {
        public int AsistenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSalida { get; set; }
        public string Tipo { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }

        // Relaciones
        public Empleado Empleado { get; set; }
    }
} 