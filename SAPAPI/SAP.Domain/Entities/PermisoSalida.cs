using System;

namespace SAP.Domain.Entities
{
    public class PermisoSalida
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

        // Relaciones
        public virtual Empleado Empleado { get; set; } = null!;
    }
} 