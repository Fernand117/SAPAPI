namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class InventarioVendedorDTO
    {
        public int UsuarioId { get; set; }
        public int ProductoId { get; set; }
        public int SucursalId { get; set; }
        public int Cantidad { get; set; }
    }
}