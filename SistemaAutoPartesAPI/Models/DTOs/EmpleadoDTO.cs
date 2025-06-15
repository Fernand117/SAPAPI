using System;

namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class EmpleadoDTO
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
    }
}