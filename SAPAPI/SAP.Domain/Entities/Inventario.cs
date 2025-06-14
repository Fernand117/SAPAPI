using System;

namespace SAP.Domain.Entities
{
    public class Inventario
    {
        public int InventarioId { get; set; }
        public int ProductoId { get; set; }
        public int SucursalId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaActualizacion { get; set; }

        // Relaciones
        public virtual Producto Producto { get; set; }
        public virtual Sucursal Sucursal { get; set; }
    }
} 