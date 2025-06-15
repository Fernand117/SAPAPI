using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models;

public partial class InventarioVendedor
{
    public int UsuarioId { get; set; }

    public int ProductoId { get; set; }

    public int SucursalId { get; set; }

    public int Cantidad { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
