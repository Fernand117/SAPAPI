using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.UnidadMoviles.Queries.GetUnidadMovilById
{
    public class GetUnidadMovilByIdQuery : IRequest<UnidadMovilDto>
    {
        public int UnidadMovilId { get; set; }
    }
} 