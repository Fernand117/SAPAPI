using System;

namespace SAP.Application.DTOs
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? UltimoAcceso { get; set; }
    }

    public class CreateUsuarioDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }

    public class UpdateUsuarioDto
    {
        public int UsuarioId { get; set; }
        public required string Email { get; set; }
        public bool Activo { get; set; }
    }

    public class UsuarioLoginDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
} 