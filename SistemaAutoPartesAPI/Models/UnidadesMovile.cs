using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models;

public partial class UnidadesMovile
{
    public int UnidadId { get; set; }

    public int SucursalId { get; set; }

    public string? Tipo { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? Placa { get; set; }

    public bool Activa { get; set; }

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual ICollection<UsuarioUnidad> UsuarioUnidads { get; set; } = new List<UsuarioUnidad>();
}
