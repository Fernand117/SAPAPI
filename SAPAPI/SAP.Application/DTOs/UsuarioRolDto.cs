using System;

namespace SAP.Application.DTOs
{
    public class UsuarioRolDto
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreRol { get; set; }
    }

    public class CreateUsuarioRolDto
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
    }

    public class UpdateUsuarioRolDto
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
    }
} 