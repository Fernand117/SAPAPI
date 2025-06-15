namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class MovimientosInventarioDTO
    {
        public int MovimientoId { get; set; }
        public int ProductoId { get; set; }
        public int SucursalId { get; set; }
        public DateTime FechaHora { get; set; }
        public string TipoMovimiento { get; set; } = null!;
        public int Cantidad { get; set; }
        public int? ReferenciaId { get; set; }
        public string? Origen { get; set; }
        public int? UsuarioId { get; set; }
        public string? Notas { get; set; }
    }
}