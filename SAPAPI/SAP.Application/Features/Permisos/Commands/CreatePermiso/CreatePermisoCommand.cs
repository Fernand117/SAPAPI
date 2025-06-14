using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Permisos.Commands.CreatePermiso
{
    public class CreatePermisoCommand : IRequest<PermisoDto>
    {
        public CreatePermisoDto CreatePermisoDto { get; set; }
    }

    public class CreatePermisoCommandHandler : IRequestHandler<CreatePermisoCommand, PermisoDto>
    {
        private readonly IGenericRepository<Permiso> _permisoRepository;
        private readonly IMapper _mapper;

        public CreatePermisoCommandHandler(IGenericRepository<Permiso> permisoRepository, IMapper mapper)
        {
            _permisoRepository = permisoRepository;
            _mapper = mapper;
        }

        public async Task<PermisoDto> Handle(CreatePermisoCommand request, CancellationToken cancellationToken)
        {
            var permiso = _mapper.Map<Permiso>(request.CreatePermisoDto);
            await _permisoRepository.AddAsync(permiso);
            return _mapper.Map<PermisoDto>(permiso);
        }
    }
} 