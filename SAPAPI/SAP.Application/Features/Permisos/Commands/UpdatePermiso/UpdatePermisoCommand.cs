using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Permisos.Commands.UpdatePermiso
{
    public class UpdatePermisoCommand : IRequest<PermisoDto>
    {
        public UpdatePermisoDto UpdatePermisoDto { get; set; }
    }

    public class UpdatePermisoCommandHandler : IRequestHandler<UpdatePermisoCommand, PermisoDto>
    {
        private readonly IGenericRepository<Permiso> _permisoRepository;
        private readonly IMapper _mapper;

        public UpdatePermisoCommandHandler(IGenericRepository<Permiso> permisoRepository, IMapper mapper)
        {
            _permisoRepository = permisoRepository;
            _mapper = mapper;
        }

        public async Task<PermisoDto> Handle(UpdatePermisoCommand request, CancellationToken cancellationToken)
        {
            var permiso = await _permisoRepository.GetByIdAsync(request.UpdatePermisoDto.PermisoId);
            if (permiso == null)
                throw new Exception($"No se encontró el permiso con ID {request.UpdatePermisoDto.PermisoId}");

            _mapper.Map(request.UpdatePermisoDto, permiso);
            await _permisoRepository.UpdateAsync(permiso);
            return _mapper.Map<PermisoDto>(permiso);
        }
    }
} 