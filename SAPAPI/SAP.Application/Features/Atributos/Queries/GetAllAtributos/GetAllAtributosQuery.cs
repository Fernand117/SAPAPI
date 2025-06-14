using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Atributos.Queries.GetAllAtributos
{
    public class GetAllAtributosQuery : IRequest<IEnumerable<AtributoDto>>
    {
    }

    public class GetAllAtributosQueryHandler : IRequestHandler<GetAllAtributosQuery, IEnumerable<AtributoDto>>
    {
        private readonly IGenericRepository<Atributo> _atributoRepository;
        private readonly IMapper _mapper;

        public GetAllAtributosQueryHandler(IGenericRepository<Atributo> atributoRepository, IMapper mapper)
        {
            _atributoRepository = atributoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AtributoDto>> Handle(GetAllAtributosQuery request, CancellationToken cancellationToken)
        {
            var atributos = await _atributoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AtributoDto>>(atributos);
        }
    }
} 