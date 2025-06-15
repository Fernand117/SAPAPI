namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class ClienteDTO
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Rfc { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public int SucursalId { get; set; }
    }
}