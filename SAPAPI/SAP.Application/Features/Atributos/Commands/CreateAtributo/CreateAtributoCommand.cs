using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Atributos.Commands.CreateAtributo
{
    public class CreateAtributoCommand : IRequest<AtributoDto>
    {
        public CreateAtributoDto CreateAtributoDto { get; set; }
    }

    public class CreateAtributoCommandHandler : IRequestHandler<CreateAtributoCommand, AtributoDto>
    {
        private readonly IGenericRepository<Atributo> _atributoRepository;
        private readonly IMapper _mapper;

        public CreateAtributoCommandHandler(IGenericRepository<Atributo> atributoRepository, IMapper mapper)
        {
            _atributoRepository = atributoRepository;
            _mapper = mapper;
        }

        public async Task<AtributoDto> Handle(CreateAtributoCommand request, CancellationToken cancellationToken)
        {
            var atributo = _mapper.Map<Atributo>(request.CreateAtributoDto);
            atributo.Activo = true;

            await _atributoRepository.AddAsync(atributo);
            return _mapper.Map<AtributoDto>(atributo);
        }
    }
} 