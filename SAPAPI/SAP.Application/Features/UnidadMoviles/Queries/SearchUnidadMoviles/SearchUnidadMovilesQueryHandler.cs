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

namespace SAP.Application.Features.UnidadMoviles.Queries.SearchUnidadMoviles
{
    public class SearchUnidadMovilesQueryHandler : IRequestHandler<SearchUnidadMovilesQuery, IEnumerable<UnidadMovilDto>>
    {
        private readonly IGenericRepository<UnidadMovil> _repository;
        private readonly IMapper _mapper;

        public SearchUnidadMovilesQueryHandler(IGenericRepository<UnidadMovil> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UnidadMovilDto>> Handle(SearchUnidadMovilesQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Query()
                .Where(x => string.IsNullOrEmpty(request.SearchTerm) ||
                           x.Placa.Contains(request.SearchTerm) ||
                           x.Modelo.Contains(request.SearchTerm) ||
                           x.Marca.Contains(request.SearchTerm))
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize);

            var unidades = await query.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<UnidadMovilDto>>(unidades);
        }
    }
} 