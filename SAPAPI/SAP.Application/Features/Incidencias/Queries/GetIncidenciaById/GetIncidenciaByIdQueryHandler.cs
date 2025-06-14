using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;
using SAP.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.Incidencias.Queries.GetIncidenciaById
{
    public class GetIncidenciaByIdQueryHandler : IRequestHandler<GetIncidenciaByIdQuery, IncidenciaDto>
    {
        private readonly IGenericRepository<Incidencia> _repository;
        private readonly IMapper _mapper;

        public GetIncidenciaByIdQueryHandler(IGenericRepository<Incidencia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IncidenciaDto> Handle(GetIncidenciaByIdQuery request, CancellationToken cancellationToken)
        {
            var incidencia = await _repository.GetByIdAsync(request.IncidenciaId);
            if (incidencia == null)
                throw new Exception($"No se encontró la incidencia con ID {request.IncidenciaId}");

            return _mapper.Map<IncidenciaDto>(incidencia);
        }
    }
} 