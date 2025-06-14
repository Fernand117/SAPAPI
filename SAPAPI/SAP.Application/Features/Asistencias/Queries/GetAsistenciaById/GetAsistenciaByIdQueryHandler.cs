using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;
using SAP.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.Asistencias.Queries.GetAsistenciaById
{
    public class GetAsistenciaByIdQueryHandler : IRequestHandler<GetAsistenciaByIdQuery, AsistenciaDto>
    {
        private readonly IGenericRepository<Asistencia> _repository;
        private readonly IMapper _mapper;

        public GetAsistenciaByIdQueryHandler(IGenericRepository<Asistencia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AsistenciaDto> Handle(GetAsistenciaByIdQuery request, CancellationToken cancellationToken)
        {
            var asistencia = await _repository.GetByIdAsync(request.Id);
            if (asistencia == null)
                throw new Exception($"No se encontró la asistencia con ID {request.Id}");

            return _mapper.Map<AsistenciaDto>(asistencia);
        }
    }
} 