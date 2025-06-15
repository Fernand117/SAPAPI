using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models;

public partial class Venta
{
    public int VentaId { get; set; }

    public int UsuarioId { get; set; }

    public int ClienteId { get; set; }

    public int SucursalId { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Total { get; set; }

    public string? FormaPago { get; set; }

    public string? Notas { get; set; }

    public string? FirmaUrl { get; set; }

    public string? UbicacionGeo { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
