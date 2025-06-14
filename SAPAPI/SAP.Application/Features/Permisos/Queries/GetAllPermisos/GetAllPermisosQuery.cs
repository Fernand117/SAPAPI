using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Permisos.Queries.GetAllPermisos
{
    public class GetAllPermisosQuery : IRequest<IEnumerable<PermisoDto>>
    {
    }

    public class GetAllPermisosQueryHandler : IRequestHandler<GetAllPermisosQuery, IEnumerable<PermisoDto>>
    {
        private readonly IGenericRepository<Permiso> _permisoRepository;
        private readonly IMapper _mapper;

        public GetAllPermisosQueryHandler(IGenericRepository<Permiso> permisoRepository, IMapper mapper)
        {
            _permisoRepository = permisoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermisoDto>> Handle(GetAllPermisosQuery request, CancellationToken cancellationToken)
        {
            var permisos = await _permisoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PermisoDto>>(permisos);
        }
    }
} 