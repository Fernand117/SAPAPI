using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Categorias.Queries.GetSubCategorias
{
    public class GetSubCategoriasQueryHandler : IRequestHandler<GetSubCategoriasQuery, IEnumerable<CategoriaDto>>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public GetSubCategoriasQueryHandler(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDto>> Handle(GetSubCategoriasQuery request, CancellationToken cancellationToken)
        {
            var subCategorias = await _categoriaRepository.GetSubCategoriasAsync(request.CategoriaPadreId);
            return _mapper.Map<IEnumerable<CategoriaDto>>(subCategorias);
        }
    }
} 