using System;

namespace SAP.Domain.Entities
{
    public class Nomina
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal Bonificaciones { get; set; }
        public decimal Deducciones { get; set; }
        public decimal Total { get; set; }
        public DateTime? FechaPago { get; set; }
        public string Estado { get; set; }

        // Relaciones
        public virtual Empleado Empleado { get; set; } = null!;
    }
} 