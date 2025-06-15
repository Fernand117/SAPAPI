using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models;

public partial class Incidencia
{
    public int IncidenciaId { get; set; }

    public int EmpleadoId { get; set; }

    public DateOnly Fecha { get; set; }

    public string? Tipo { get; set; }

    public string? Descripcion { get; set; }

    public bool Justificada { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;
}
