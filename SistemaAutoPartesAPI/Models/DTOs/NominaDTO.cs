namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class NominaDTO
    {
        public int NominaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public decimal SueldoBase { get; set; }
        public decimal Bonos { get; set; }
        public decimal Deducciones { get; set; }
        public decimal TotalPagar { get; set; }
        public DateOnly? FechaPago { get; set; }
        public string? Estado { get; set; }
    }
}