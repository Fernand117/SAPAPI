using System;

namespace SAP.Domain.Entities
{
    public class Inventario
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int SucursalId { get; set; }
        public int Cantidad { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public DateTime FechaActualizacion { get; set; }

        // Relaciones
        public virtual Producto Producto { get; set; } = null!;
        public virtual Sucursal Sucursal { get; set; } = null!;
    }
} 