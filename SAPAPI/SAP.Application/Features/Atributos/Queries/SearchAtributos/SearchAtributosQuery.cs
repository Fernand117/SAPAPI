using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Atributos.Queries.SearchAtributos
{
    public class SearchAtributosQuery : IRequest<IEnumerable<AtributoDto>>
    {
        public string SearchTerm { get; set; }
    }

    public class SearchAtributosQueryHandler : IRequestHandler<SearchAtributosQuery, IEnumerable<AtributoDto>>
    {
        private readonly IGenericRepository<Atributo> _atributoRepository;
        private readonly IMapper _mapper;

        public SearchAtributosQueryHandler(IGenericRepository<Atributo> atributoRepository, IMapper mapper)
        {
            _atributoRepository = atributoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AtributoDto>> Handle(SearchAtributosQuery request, CancellationToken cancellationToken)
        {
            var atributos = await _atributoRepository.GetAllAsync();
            var filteredAtributos = atributos.Where(a => 
                a.Nombre.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                a.Descripcion.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                a.Tipo.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase));

            return _mapper.Map<IEnumerable<AtributoDto>>(filteredAtributos);
        }
    }
} 