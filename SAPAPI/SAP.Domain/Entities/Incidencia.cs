using System;

namespace SAP.Domain.Entities
{
    public class Incidencia
    {
        public int IncidenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public bool Justificada { get; set; }

        // Relaciones
        public Empleado Empleado { get; set; }
    }
} 