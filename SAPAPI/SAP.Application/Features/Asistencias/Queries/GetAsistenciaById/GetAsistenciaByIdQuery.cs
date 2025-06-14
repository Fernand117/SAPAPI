using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Asistencias.Queries.GetAsistenciaById
{
    public class GetAsistenciaByIdQuery : IRequest<AsistenciaDto>
    {
        public int AsistenciaId { get; set; }
        public int Id { get; set; }
    }
} 