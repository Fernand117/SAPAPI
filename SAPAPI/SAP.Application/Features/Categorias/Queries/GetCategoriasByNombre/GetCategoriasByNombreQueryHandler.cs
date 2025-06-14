using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Categorias.Queries.GetCategoriasByNombre
{
    public class GetCategoriasByNombreQueryHandler : IRequestHandler<GetCategoriasByNombreQuery, IEnumerable<CategoriaDto>>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public GetCategoriasByNombreQueryHandler(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDto>> Handle(GetCategoriasByNombreQuery request, CancellationToken cancellationToken)
        {
            var categorias = await _categoriaRepository.GetByNombreAsync(request.Nombre);
            return _mapper.Map<IEnumerable<CategoriaDto>>(categorias);
        }
    }
} 