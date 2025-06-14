using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Roles.Commands.CreateRol
{
    public class CreateRolCommand : IRequest<RolDto>
    {
        public CreateRolDto CreateRolDto { get; set; }
    }

    public class CreateRolCommandHandler : IRequestHandler<CreateRolCommand, RolDto>
    {
        private readonly IGenericRepository<Rol> _rolRepository;
        private readonly IMapper _mapper;

        public CreateRolCommandHandler(IGenericRepository<Rol> rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        public async Task<RolDto> Handle(CreateRolCommand request, CancellationToken cancellationToken)
        {
            var rol = _mapper.Map<Rol>(request.CreateRolDto);
            rol.Activo = true;

            await _rolRepository.AddAsync(rol);
            return _mapper.Map<RolDto>(rol);
        }
    }
} 