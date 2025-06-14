using System;

namespace SAP.Application.DTOs
{
    public class IncidenciaDto
    {
        public int IncidenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Observaciones { get; set; } = null!;
    }

    public class CreateIncidenciaDto
    {
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
    }

    public class UpdateIncidenciaDto
    {
        public int IncidenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
    }
} 