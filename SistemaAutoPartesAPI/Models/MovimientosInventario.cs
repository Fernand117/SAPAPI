using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAutoPartesAPI.Models;

public partial class MovimientosInventario
{
    public int MovimientoId { get; set; }

    public int ProductoId { get; set; }

    public int SucursalId { get; set; }

    [Column(TypeName = "timestamp")]
    public DateTime FechaHora { get; set; } = DateTime.Now;

    public string TipoMovimiento { get; set; } = null!;

    public int Cantidad { get; set; }

    public int? ReferenciaId { get; set; }

    public string? Origen { get; set; }

    public int? UsuarioId { get; set; }

    public string? Notas { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Sucursale Sucursal { get; set; } = null!;
}
