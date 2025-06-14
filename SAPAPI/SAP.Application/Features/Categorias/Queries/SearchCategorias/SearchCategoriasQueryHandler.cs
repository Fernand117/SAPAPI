using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Categorias.Queries.SearchCategorias
{
    public class SearchCategoriasQueryHandler : IRequestHandler<SearchCategoriasQuery, IEnumerable<CategoriaDto>>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public SearchCategoriasQueryHandler(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDto>> Handle(SearchCategoriasQuery request, CancellationToken cancellationToken)
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            var categoriasFiltradas = categorias.Where(c => 
                c.Nombre.Contains(request.SearchTerm, System.StringComparison.OrdinalIgnoreCase) ||
                c.Descripcion.Contains(request.SearchTerm, System.StringComparison.OrdinalIgnoreCase));
            
            return _mapper.Map<IEnumerable<CategoriaDto>>(categoriasFiltradas);
        }
    }
} 