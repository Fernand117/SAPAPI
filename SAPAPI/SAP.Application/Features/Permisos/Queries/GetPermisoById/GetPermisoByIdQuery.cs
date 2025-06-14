using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Permisos.Queries.GetPermisoById
{
    public class GetPermisoByIdQuery : IRequest<PermisoDto>
    {
        public int PermisoId { get; set; }
    }

    public class GetPermisoByIdQueryHandler : IRequestHandler<GetPermisoByIdQuery, PermisoDto>
    {
        private readonly IGenericRepository<Permiso> _permisoRepository;
        private readonly IMapper _mapper;

        public GetPermisoByIdQueryHandler(IGenericRepository<Permiso> permisoRepository, IMapper mapper)
        {
            _permisoRepository = permisoRepository;
            _mapper = mapper;
        }

        public async Task<PermisoDto> Handle(GetPermisoByIdQuery request, CancellationToken cancellationToken)
        {
            var permiso = await _permisoRepository.GetByIdAsync(request.PermisoId);
            if (permiso == null)
                throw new Exception($"No se encontró el permiso con ID {request.PermisoId}");

            return _mapper.Map<PermisoDto>(permiso);
        }
    }
} 