namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class IncidenciaDTO
    {
        public int IncidenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateOnly Fecha { get; set; }
        public string? Tipo { get; set; }
        public string? Descripcion { get; set; }
        public bool Justificada { get; set; }
    }
}