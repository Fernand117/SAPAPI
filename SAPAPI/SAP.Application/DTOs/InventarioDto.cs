using System;

namespace SAP.Application.DTOs
{
    public class InventarioDto
    {
        public int InventarioId { get; set; }
        public int ProductoId { get; set; }
        public int SucursalId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaActualizacion { get; set; }

        // Propiedades de navegación
        public string NombreProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreSucursal { get; set; }
        public decimal PrecioVenta { get; set; }
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

    public class InventarioDetalleDto : InventarioDto
    {
        public ProductoDto Producto { get; set; }
        public SucursalDto Sucursal { get; set; }
    }
} 