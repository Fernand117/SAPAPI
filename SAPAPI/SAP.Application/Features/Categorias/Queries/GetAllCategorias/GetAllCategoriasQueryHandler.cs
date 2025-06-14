using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Categorias.Queries.GetAllCategorias
{
    public class GetAllCategoriasQueryHandler : IRequestHandler<GetAllCategoriasQuery, IEnumerable<CategoriaDto>>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriasQueryHandler(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDto>> Handle(GetAllCategoriasQuery request, CancellationToken cancellationToken)
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            
            if (request.SoloActivas)
                categorias = categorias.Where(c => c.Activa);

            var categoriasDto = _mapper.Map<IEnumerable<CategoriaDto>>(categorias);

            if (request.IncluirSubCategorias)
            {
                foreach (var categoria in categoriasDto)
                {
                    var subCategorias = await _categoriaRepository.GetSubCategoriasAsync(categoria.CategoriaId);
                    categoria.SubCategorias = _mapper.Map<ICollection<CategoriaDto>>(subCategorias);
                }
            }

            return categoriasDto;
        }
    }
} 