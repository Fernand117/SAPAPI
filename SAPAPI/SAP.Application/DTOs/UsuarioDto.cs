using System;

namespace SAP.Application.DTOs
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? UltimoAcceso { get; set; }
    }

    public class CreateUsuarioDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class UpdateUsuarioDto
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
    }

    public class UsuarioLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
} 