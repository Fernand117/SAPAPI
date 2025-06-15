using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class PermisosSalidumDTO
    {
        public int IdPermisoSalida { get; set; }
        public int IdEmpleado { get; set; }
        public DateOnly FechaSolicitud { get; set; }
        public TimeOnly? HoraSalida { get; set; }
        public TimeOnly? HoraRegreso { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
    }
}