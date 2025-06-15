namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class SucursalDTO
    {
        public int SucursalId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Estado { get; set; }
        public string? Telefono { get; set; }
    }
}