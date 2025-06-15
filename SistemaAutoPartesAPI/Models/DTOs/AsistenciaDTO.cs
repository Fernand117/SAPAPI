namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class AsistenciaDTO
    {
        public int AsistenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly? HoraEntrada { get; set; }
        public TimeOnly? HoraSalida { get; set; }
        public string? Observaciones { get; set; }
    }
}