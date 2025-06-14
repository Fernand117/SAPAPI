using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Categorias.Queries.GetCategoriasActivas
{
    public class GetCategoriasActivasQueryHandler : IRequestHandler<GetCategoriasActivasQuery, IEnumerable<CategoriaDto>>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public GetCategoriasActivasQueryHandler(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDto>> Handle(GetCategoriasActivasQuery request, CancellationToken cancellationToken)
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            var categoriasActivas = categorias.Where(c => c.Activa);
            return _mapper.Map<IEnumerable<CategoriaDto>>(categoriasActivas);
        }
    }
} 