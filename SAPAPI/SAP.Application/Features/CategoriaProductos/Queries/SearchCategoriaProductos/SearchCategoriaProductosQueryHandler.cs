using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SAP.Application.DTOs;
using SAP.Application.Interfaces;
using SAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.CategoriaProductos.Queries.SearchCategoriaProductos
{
    public class SearchCategoriaProductosQueryHandler : IRequestHandler<SearchCategoriaProductosQuery, IEnumerable<CategoriaProductoDto>>
    {
        private readonly IGenericRepository<CategoriaProducto> _repository;
        private readonly IMapper _mapper;

        public SearchCategoriaProductosQueryHandler(IGenericRepository<CategoriaProducto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaProductoDto>> Handle(SearchCategoriaProductosQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Query()
                .Where(x => string.IsNullOrEmpty(request.SearchTerm) ||
                           x.Nombre.Contains(request.SearchTerm) ||
                           x.Descripcion.Contains(request.SearchTerm))
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize);

            var categorias = await query.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<CategoriaProductoDto>>(categorias);
        }
    }
} 