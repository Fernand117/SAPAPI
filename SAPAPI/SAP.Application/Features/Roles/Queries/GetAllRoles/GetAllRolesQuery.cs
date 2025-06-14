using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQuery : IRequest<IEnumerable<RolDto>>
    {
    }

    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<RolDto>>
    {
        private readonly IGenericRepository<Rol> _rolRepository;
        private readonly IMapper _mapper;

        public GetAllRolesQueryHandler(IGenericRepository<Rol> rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RolDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _rolRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RolDto>>(roles);
        }
    }
} 