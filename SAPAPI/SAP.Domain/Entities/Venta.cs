using System;
using System.Collections.Generic;

namespace SAP.Domain.Entities
{
    public class Venta
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public int SucursalId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public string FormaPago { get; set; }
        public string Notas { get; set; }
        public string FirmaUrl { get; set; }
        public string UbicacionGeo { get; set; }

        // Relaciones
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
        public Sucursal Sucursal { get; set; }
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
} 