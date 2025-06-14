using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Incidencias.Commands.UpdateIncidencia
{
    public class UpdateIncidenciaCommand : IRequest<IncidenciaDto>
    {
        public int IncidenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Observaciones { get; set; } = null!;
    }
} 