using System;

namespace SAP.Domain.Entities
{
    public class InventarioVendedor
    {
        public int InventarioVendedorId { get; set; }
        public int ProductoId { get; set; }
        public int EmpleadoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaAsignacion { get; set; }

        // Relaciones
        public Producto Producto { get; set; }
        public Empleado Empleado { get; set; }
    }
} 