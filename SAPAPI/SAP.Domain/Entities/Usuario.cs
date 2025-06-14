using System;
using System.Collections.Generic;

namespace SAP.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public int EmpleadoId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? UltimoAcceso { get; set; }

        // Relaciones
        public virtual Empleado Empleado { get; set; }
        public virtual ICollection<UsuarioRol> UsuarioRoles { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }
        public virtual ICollection<InventarioVendedor> InventarioVendedores { get; set; }
        public virtual ICollection<UsuarioUnidad> UsuarioUnidades { get; set; }
        public virtual ICollection<Bitacora> Bitacoras { get; set; }
    }
} 