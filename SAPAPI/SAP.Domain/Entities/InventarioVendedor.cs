using System;

namespace SAP.Domain.Entities
{
    public class InventarioVendedor
    {
        public int Id { get; set; }
        public int VendedorId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaAsignacion { get; set; }

        // Relaciones
        public virtual Empleado Vendedor { get; set; } = null!;
        public virtual Producto Producto { get; set; } = null!;
    }
} 