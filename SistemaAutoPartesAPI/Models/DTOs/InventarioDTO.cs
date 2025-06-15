namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class InventarioDTO
    {
        public int InventarioId { get; set; }
        public int ProductoId { get; set; }
        public int SucursalId { get; set; }
        public int Cantidad { get; set; }
    }
}