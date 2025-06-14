using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Atributos.Queries.GetAtributoById
{
    public class GetAtributoByIdQuery : IRequest<AtributoDto>
    {
        public int AtributoId { get; set; }
    }

    public class GetAtributoByIdQueryHandler : IRequestHandler<GetAtributoByIdQuery, AtributoDto>
    {
        private readonly IGenericRepository<Atributo> _atributoRepository;
        private readonly IMapper _mapper;

        public GetAtributoByIdQueryHandler(IGenericRepository<Atributo> atributoRepository, IMapper mapper)
        {
            _atributoRepository = atributoRepository;
            _mapper = mapper;
        }

        public async Task<AtributoDto> Handle(GetAtributoByIdQuery request, CancellationToken cancellationToken)
        {
            var atributo = await _atributoRepository.GetByIdAsync(request.AtributoId);
            if (atributo == null)
                throw new Exception($"No se encontró el atributo con ID {request.AtributoId}");

            return _mapper.Map<AtributoDto>(atributo);
        }
    }
} 