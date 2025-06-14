using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Roles.Commands.UpdateRol
{
    public class UpdateRolCommand : IRequest<RolDto>
    {
        public UpdateRolDto UpdateRolDto { get; set; }
    }

    public class UpdateRolCommandHandler : IRequestHandler<UpdateRolCommand, RolDto>
    {
        private readonly IGenericRepository<Rol> _rolRepository;
        private readonly IMapper _mapper;

        public UpdateRolCommandHandler(IGenericRepository<Rol> rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        public async Task<RolDto> Handle(UpdateRolCommand request, CancellationToken cancellationToken)
        {
            var rol = await _rolRepository.GetByIdAsync(request.UpdateRolDto.RolId);
            if (rol == null)
                throw new Exception($"No se encontró el rol con ID {request.UpdateRolDto.RolId}");

            _mapper.Map(request.UpdateRolDto, rol);
            await _rolRepository.UpdateAsync(rol);
            return _mapper.Map<RolDto>(rol);
        }
    }
} 