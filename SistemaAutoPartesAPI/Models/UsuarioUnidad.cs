using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models;

public partial class UsuarioUnidad
{
    public int UsuarioId { get; set; }

    public int UnidadId { get; set; }

    public int SucursalId { get; set; }

    public DateOnly FechaAsignacion { get; set; }

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual UnidadesMovile Unidad { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
