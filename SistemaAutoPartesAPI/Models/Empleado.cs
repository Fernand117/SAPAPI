using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public string? Curp { get; set; }

    public string? Rfc { get; set; }

    public string? Nss { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public bool Activo { get; set; }

    public int SucursalId { get; set; }

    public string? FotoUrl { get; set; }

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual ICollection<Incidencia> Incidencia { get; set; } = new List<Incidencia>();

    public virtual ICollection<Nomina> Nominas { get; set; } = new List<Nomina>();

    public virtual ICollection<PermisosSalidum> PermisosSalida { get; set; } = new List<PermisosSalidum>();

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
