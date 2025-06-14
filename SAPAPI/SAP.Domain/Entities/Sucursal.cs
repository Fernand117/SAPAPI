using System;
using System.Collections.Generic;

namespace SAP.Domain.Entities
{
    public class Sucursal
    {
        public int SucursalId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activa { get; set; }
        public DateTime FechaApertura { get; set; }

        // Relaciones
        public ICollection<Empleado> Empleados { get; set; }
        public ICollection<Inventario> Inventarios { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
} 