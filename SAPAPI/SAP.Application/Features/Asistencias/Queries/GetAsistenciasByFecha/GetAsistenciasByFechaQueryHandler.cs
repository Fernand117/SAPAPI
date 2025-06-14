using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Asistencias.Queries.GetAsistenciasByFecha
{
    public class GetAsistenciasByFechaQueryHandler : IRequestHandler<GetAsistenciasByFechaQuery, IEnumerable<AsistenciaDto>>
    {
        private readonly IAsistenciaRepository _asistenciaRepository;
        private readonly IMapper _mapper;

        public GetAsistenciasByFechaQueryHandler(IAsistenciaRepository asistenciaRepository, IMapper mapper)
        {
            _asistenciaRepository = asistenciaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AsistenciaDto>> Handle(GetAsistenciasByFechaQuery request, CancellationToken cancellationToken)
        {
            var asistencias = await _asistenciaRepository.GetByFechaAsync(request.Fecha);
            return _mapper.Map<IEnumerable<AsistenciaDto>>(asistencias);
        }
    }
} 