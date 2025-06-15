namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class BitacoraDTO
    {
        public int BitacoraId { get; set; }
        public DateTime FechaHora { get; set; }
        public int UsuarioId { get; set; }
        public int SucursalId { get; set; }
        public string Accion { get; set; } = null!;
        public string Tabla { get; set; } = null!;
        public int? RegistroId { get; set; }
        public string? Detalles { get; set; }
        public string? Ip { get; set; }
    }
}