using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;
using SAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.Incidencias.Queries.SearchIncidencias
{
    public class SearchIncidenciasQueryHandler : IRequestHandler<SearchIncidenciasQuery, IEnumerable<IncidenciaDto>>
    {
        private readonly IGenericRepository<Incidencia> _repository;
        private readonly IMapper _mapper;

        public SearchIncidenciasQueryHandler(IGenericRepository<Incidencia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IncidenciaDto>> Handle(SearchIncidenciasQuery request, CancellationToken cancellationToken)
        {
            var incidencias = await _repository.GetAllAsync();
            var filteredIncidencias = incidencias
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize);

            return _mapper.Map<IEnumerable<IncidenciaDto>>(filteredIncidencias);
        }
    }
} 