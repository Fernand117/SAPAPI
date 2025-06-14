namespace SAP.Application.DTOs
{
    public class InventarioDto
    {
        public int InventarioId { get; set; }
        public int ProductoId { get; set; }
        public string? ProductoNombre { get; set; }
        public int SucursalId { get; set; }
        public string? SucursalNombre { get; set; }
        public int Cantidad { get; set; }
    }

    public class CreateInventarioDto
    {
        public int ProductoId { get; set; }
        public int SucursalId { get; set; }
        public int Cantidad { get; set; }
    }

    public class UpdateInventarioDto
    {
        public int InventarioId { get; set; }
        public int Cantidad { get; set; }
    }
} 