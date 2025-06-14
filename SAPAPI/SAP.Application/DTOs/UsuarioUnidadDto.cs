using System;

namespace SAP.Application.DTOs
{
    public class UsuarioUnidadDto
    {
        public int UsuarioId { get; set; }
        public int UnidadId { get; set; }
        public int SucursalId { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime? FechaDesasignacion { get; set; }
        public bool Activa { get; set; }
        public string NombreUsuario { get; set; }
        public string PlacaUnidad { get; set; }
        public string NombreSucursal { get; set; }
    }

    public class CreateUsuarioUnidadDto
    {
        public int UsuarioId { get; set; }
        public int UnidadId { get; set; }
        public int SucursalId { get; set; }
    }

    public class UpdateUsuarioUnidadDto
    {
        public int UsuarioId { get; set; }
        public int UnidadId { get; set; }
        public DateTime? FechaDesasignacion { get; set; }
        public bool Activa { get; set; }
    }
} 