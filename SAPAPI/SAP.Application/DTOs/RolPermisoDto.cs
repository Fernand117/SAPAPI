using System;

namespace SAP.Application.DTOs
{
    public class RolPermisoDto
    {
        public int RolId { get; set; }
        public int PermisoId { get; set; }
        public string NombreRol { get; set; }
        public string NombrePermiso { get; set; }
    }

    public class CreateRolPermisoDto
    {
        public int RolId { get; set; }
        public int PermisoId { get; set; }
    }

    public class UpdateRolPermisoDto
    {
        public int RolId { get; set; }
        public int PermisoId { get; set; }
    }
} 