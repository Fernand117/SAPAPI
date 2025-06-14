using System;

namespace SAP.Application.DTOs
{
    public class AsistenciaDto
    {
        public int AsistenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public string? EmpleadoNombre { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan? HoraEntrada { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public string? Observaciones { get; set; }
    }

    public class CreateAsistenciaDto
    {
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan? HoraEntrada { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public string? Observaciones { get; set; }
    }

    public class UpdateAsistenciaDto
    {
        public int AsistenciaId { get; set; }
        public TimeSpan? HoraEntrada { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public string? Observaciones { get; set; }
    }

    public class IncidenciaDto
    {
        public int IncidenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public string? EmpleadoNombre { get; set; }
        public DateTime Fecha { get; set; }
        public string? Tipo { get; set; }
        public string? Observaciones { get; set; }
        public bool Justificada { get; set; }
    }

    public class CreateIncidenciaDto
    {
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public string? Tipo { get; set; }
        public string? Observaciones { get; set; }
        public bool Justificada { get; set; }
    }

    public class UpdateIncidenciaDto
    {
        public int IncidenciaId { get; set; }
        public string? Tipo { get; set; }
        public string? Observaciones { get; set; }
        public bool Justificada { get; set; }
    }
} 