namespace SAP.Domain.Entities;

public class DetalleVenta
{
    public int Id { get; set; }
    public int VentaId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
    
    public virtual Venta Venta { get; set; } = null!;
    public virtual Producto Producto { get; set; } = null!;
} 