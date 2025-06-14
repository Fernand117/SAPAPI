namespace SAP.Application.DTOs
{
    public class DetalleVentaDto
    {
        public int DetalleId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public string? ProductoNombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }

    public class CreateDetalleVentaDto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

    public class UpdateDetalleVentaDto
    {
        public int DetalleId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

    public class DetalleVentaDetalleDto : DetalleVentaDto
    {
        public ProductoDto? Producto { get; set; }
    }
} 