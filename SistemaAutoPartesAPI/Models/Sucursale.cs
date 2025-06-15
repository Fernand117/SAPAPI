using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models;

public partial class Sucursale
{
    public int SucursalId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Estado { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Bitacora> Bitacoras { get; set; } = new List<Bitacora>();

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<InventarioVendedor> InventarioVendedors { get; set; } = new List<InventarioVendedor>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();

    public virtual ICollection<UnidadesMovile> UnidadesMoviles { get; set; } = new List<UnidadesMovile>();

    public virtual ICollection<UsuarioUnidad> UsuarioUnidads { get; set; } = new List<UsuarioUnidad>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
