using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Incidencias.Queries.GetIncidenciaById
{
    public class GetIncidenciaByIdQuery : IRequest<IncidenciaDto>
    {
        public int IncidenciaId { get; set; }
    }
} 