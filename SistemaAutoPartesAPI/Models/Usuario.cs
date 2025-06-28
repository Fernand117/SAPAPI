using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public int EmpleadoId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public bool Activo { get; set; }
    public int[] RolId { get; set; }

    public virtual ICollection<Bitacora> Bitacoras { get; set; } = new List<Bitacora>();

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual ICollection<InventarioVendedor> InventarioVendedors { get; set; } = new List<InventarioVendedor>();

    public virtual ICollection<UsuarioUnidad> UsuarioUnidads { get; set; } = new List<UsuarioUnidad>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();

    public virtual ICollection<Role> Rols { get; set; } = new List<Role>();
}
