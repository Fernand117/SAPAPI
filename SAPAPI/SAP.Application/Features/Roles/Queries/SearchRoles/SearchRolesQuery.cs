using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Roles.Queries.SearchRoles
{
    public class SearchRolesQuery : IRequest<IEnumerable<RolDto>>
    {
        public string SearchTerm { get; set; }
    }

    public class SearchRolesQueryHandler : IRequestHandler<SearchRolesQuery, IEnumerable<RolDto>>
    {
        private readonly IGenericRepository<Rol> _rolRepository;
        private readonly IMapper _mapper;

        public SearchRolesQueryHandler(IGenericRepository<Rol> rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RolDto>> Handle(SearchRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _rolRepository.GetAllAsync();
            var filteredRoles = roles.Where(r => 
                r.Nombre.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                r.Descripcion.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase));

            return _mapper.Map<IEnumerable<RolDto>>(filteredRoles);
        }
    }
} 