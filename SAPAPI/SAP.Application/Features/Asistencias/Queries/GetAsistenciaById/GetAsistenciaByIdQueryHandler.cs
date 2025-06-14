using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Asistencias.Queries.GetAsistenciaById
{
    public class GetAsistenciaByIdQueryHandler : IRequestHandler<GetAsistenciaByIdQuery, AsistenciaDto>
    {
        private readonly IAsistenciaRepository _asistenciaRepository;
        private readonly IMapper _mapper;

        public GetAsistenciaByIdQueryHandler(IAsistenciaRepository asistenciaRepository, IMapper mapper)
        {
            _asistenciaRepository = asistenciaRepository;
            _mapper = mapper;
        }

        public async Task<AsistenciaDto> Handle(GetAsistenciaByIdQuery request, CancellationToken cancellationToken)
        {
            var asistencia = await _asistenciaRepository.GetByIdAsync(request.AsistenciaId);
            return _mapper.Map<AsistenciaDto>(asistencia);
        }
    }
} 