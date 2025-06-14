using System;
using System.Collections.Generic;

namespace SAP.Domain.Entities
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaContratacion { get; set; }
        public decimal Salario { get; set; }
        public string Cargo { get; set; }
        public bool Activo { get; set; }
        public int? UsuarioId { get; set; }
        public int SucursalId { get; set; }

        // Relaciones
        public Usuario Usuario { get; set; }
        public Sucursal Sucursal { get; set; }
        public ICollection<Asistencia> Asistencias { get; set; }
        public ICollection<Incidencia> Incidencias { get; set; }
        public ICollection<PermisoSalida> PermisosSalida { get; set; }
        public ICollection<InventarioVendedor> InventarioVendedores { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
} 