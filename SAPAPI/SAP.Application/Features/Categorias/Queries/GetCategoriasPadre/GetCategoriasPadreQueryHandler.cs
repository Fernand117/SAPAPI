using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Categorias.Queries.GetCategoriasPadre
{
    public class GetCategoriasPadreQueryHandler : IRequestHandler<GetCategoriasPadreQuery, IEnumerable<CategoriaDto>>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public GetCategoriasPadreQueryHandler(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDto>> Handle(GetCategoriasPadreQuery request, CancellationToken cancellationToken)
        {
            var categorias = await _categoriaRepository.GetCategoriasPadreAsync();
            return _mapper.Map<IEnumerable<CategoriaDto>>(categorias);
        }
    }
} 