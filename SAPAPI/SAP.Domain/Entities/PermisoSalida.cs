using System;

namespace SAP.Domain.Entities
{
    public class PermisoSalida
    {
        public int PermisoSalidaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }

        // Relaciones
        public Empleado Empleado { get; set; }
    }
} 