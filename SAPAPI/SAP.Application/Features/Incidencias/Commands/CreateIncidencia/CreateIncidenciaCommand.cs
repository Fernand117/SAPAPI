using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Incidencias.Commands.CreateIncidencia
{
    public class CreateIncidenciaCommand : IRequest<IncidenciaDto>
    {
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
    }
} 