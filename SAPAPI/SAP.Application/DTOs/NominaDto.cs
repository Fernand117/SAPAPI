using System;

namespace SAP.Application.DTOs
{
    public class NominaDto
    {
        public int NominaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal Bonificaciones { get; set; }
        public decimal Deducciones { get; set; }
        public decimal Total { get; set; }
        public DateTime? FechaPago { get; set; }
        public string Estado { get; set; }
        public string NombreEmpleado { get; set; }
    }

    public class CreateNominaDto
    {
        public int EmpleadoId { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal Bonificaciones { get; set; }
        public decimal Deducciones { get; set; }
    }

    public class UpdateNominaDto
    {
        public int NominaId { get; set; }
        public decimal Bonificaciones { get; set; }
        public decimal Deducciones { get; set; }
        public DateTime? FechaPago { get; set; }
        public string Estado { get; set; }
    }
} 