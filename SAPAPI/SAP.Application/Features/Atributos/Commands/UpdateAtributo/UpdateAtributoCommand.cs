using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Atributos.Commands.UpdateAtributo
{
    public class UpdateAtributoCommand : IRequest<AtributoDto>
    {
        public UpdateAtributoDto UpdateAtributoDto { get; set; }
    }

    public class UpdateAtributoCommandHandler : IRequestHandler<UpdateAtributoCommand, AtributoDto>
    {
        private readonly IGenericRepository<Atributo> _atributoRepository;
        private readonly IMapper _mapper;

        public UpdateAtributoCommandHandler(IGenericRepository<Atributo> atributoRepository, IMapper mapper)
        {
            _atributoRepository = atributoRepository;
            _mapper = mapper;
        }

        public async Task<AtributoDto> Handle(UpdateAtributoCommand request, CancellationToken cancellationToken)
        {
            var atributo = await _atributoRepository.GetByIdAsync(request.UpdateAtributoDto.AtributoId);
            if (atributo == null)
                throw new Exception($"No se encontró el atributo con ID {request.UpdateAtributoDto.AtributoId}");

            _mapper.Map(request.UpdateAtributoDto, atributo);
            await _atributoRepository.UpdateAsync(atributo);
            return _mapper.Map<AtributoDto>(atributo);
        }
    }
} 