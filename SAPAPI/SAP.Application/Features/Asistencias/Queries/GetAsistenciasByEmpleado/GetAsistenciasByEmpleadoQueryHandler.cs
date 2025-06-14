using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Asistencias.Queries.GetAsistenciasByEmpleado
{
    public class GetAsistenciasByEmpleadoQueryHandler : IRequestHandler<GetAsistenciasByEmpleadoQuery, IEnumerable<AsistenciaDto>>
    {
        private readonly IAsistenciaRepository _asistenciaRepository;
        private readonly IMapper _mapper;

        public GetAsistenciasByEmpleadoQueryHandler(IAsistenciaRepository asistenciaRepository, IMapper mapper)
        {
            _asistenciaRepository = asistenciaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AsistenciaDto>> Handle(GetAsistenciasByEmpleadoQuery request, CancellationToken cancellationToken)
        {
            var asistencias = await _asistenciaRepository.GetByEmpleadoAndFechaRangeAsync(
                request.EmpleadoId,
                request.FechaInicio,
                request.FechaFin
            );
            return _mapper.Map<IEnumerable<AsistenciaDto>>(asistencias);
        }
    }
} 