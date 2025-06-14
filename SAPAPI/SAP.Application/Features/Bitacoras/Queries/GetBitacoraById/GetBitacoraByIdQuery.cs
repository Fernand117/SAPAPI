using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Bitacoras.Queries.GetBitacoraById
{
    public class GetBitacoraByIdQuery : IRequest<BitacoraDto>
    {
        public int BitacoraId { get; set; }
    }
} 