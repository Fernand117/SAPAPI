using System;

namespace SAP.Application.DTOs
{
    public class RolDto
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }

    public class CreateRolDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class UpdateRolDto
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
} 