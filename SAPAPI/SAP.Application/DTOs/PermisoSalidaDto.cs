using System;

namespace SAP.Application.DTOs
{
    public class PermisoSalidaDto
    {
        public int PermisoSalidaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
        public string NombreEmpleado { get; set; }
    }

    public class CreatePermisoSalidaDto
    {
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string Motivo { get; set; }
    }

    public class UpdatePermisoSalidaDto
    {
        public int PermisoSalidaId { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
    }
} 