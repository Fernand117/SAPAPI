using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models;

public partial class Permiso
{
    public int PermisoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Modulo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Role> Rols { get; set; } = new List<Role>();
}
