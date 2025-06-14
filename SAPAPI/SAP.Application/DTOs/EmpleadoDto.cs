using System;

namespace SAP.Application.DTOs
{
    public class EmpleadoDto
    {
        public int EmpleadoId { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }
        public required string Email { get; set; }
        public DateTime FechaContratacion { get; set; }
        public decimal Salario { get; set; }
        public required string Cargo { get; set; }
        public bool Activo { get; set; }
        public int? UsuarioId { get; set; }
        public int SucursalId { get; set; }
        public string? SucursalNombre { get; set; }
    }

    public class CreateEmpleadoDto
    {
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }
        public required string Email { get; set; }
        public DateTime FechaContratacion { get; set; }
        public decimal Salario { get; set; }
        public required string Cargo { get; set; }
        public int SucursalId { get; set; }
        public int? UsuarioId { get; set; }
    }

    public class UpdateEmpleadoDto
    {
        public int EmpleadoId { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }
        public required string Email { get; set; }
        public DateTime FechaContratacion { get; set; }
        public decimal Salario { get; set; }
        public required string Cargo { get; set; }
        public bool Activo { get; set; }
        public int SucursalId { get; set; }
        public int? UsuarioId { get; set; }
    }
} 