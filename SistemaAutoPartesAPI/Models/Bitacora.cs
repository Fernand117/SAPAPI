using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models;

public partial class Bitacora
{
    public int BitacoraId { get; set; }

    public DateTime FechaHora { get; set; }

    public int UsuarioId { get; set; }

    public int SucursalId { get; set; }

    public string Accion { get; set; } = null!;

    public string Tabla { get; set; } = null!;

    public int? RegistroId { get; set; }

    public string? Detalles { get; set; }

    public string? Ip { get; set; }

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
