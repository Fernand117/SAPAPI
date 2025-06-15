using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models;

public partial class PermisosSalidum
{
    public int PermisoId { get; set; }

    public int EmpleadoId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly? HoraSalida { get; set; }

    public TimeOnly? HoraRegreso { get; set; }

    public string? Motivo { get; set; }

    public bool Autorizado { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;
}
