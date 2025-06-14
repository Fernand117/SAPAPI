using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;
using SAP.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.UnidadMoviles.Queries.GetUnidadMovilById
{
    public class GetUnidadMovilByIdQueryHandler : IRequestHandler<GetUnidadMovilByIdQuery, UnidadMovilDto>
    {
        private readonly IGenericRepository<UnidadMovil> _repository;
        private readonly IMapper _mapper;

        public GetUnidadMovilByIdQueryHandler(IGenericRepository<UnidadMovil> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UnidadMovilDto> Handle(GetUnidadMovilByIdQuery request, CancellationToken cancellationToken)
        {
            var unidadMovil = await _repository.GetByIdAsync(request.UnidadMovilId);
            if (unidadMovil == null)
                throw new Exception($"No se encontró la unidad móvil con ID {request.UnidadMovilId}");

            return _mapper.Map<UnidadMovilDto>(unidadMovil);
        }
    }
} 