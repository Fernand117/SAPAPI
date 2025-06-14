using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Permisos.Queries.SearchPermisos
{
    public class SearchPermisosQuery : IRequest<IEnumerable<PermisoDto>>
    {
        public string? SearchTerm { get; set; }
    }

    public class SearchPermisosQueryHandler : IRequestHandler<SearchPermisosQuery, IEnumerable<PermisoDto>>
    {
        private readonly IGenericRepository<Permiso> _permisoRepository;
        private readonly IMapper _mapper;

        public SearchPermisosQueryHandler(IGenericRepository<Permiso> permisoRepository, IMapper mapper)
        {
            _permisoRepository = permisoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermisoDto>> Handle(SearchPermisosQuery request, CancellationToken cancellationToken)
        {
            var permisos = await _permisoRepository.GetAllAsync();
            var filteredPermisos = permisos.Where(p => 
                p.Nombre.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                p.Descripcion.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                p.Modulo.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase));

            return _mapper.Map<IEnumerable<PermisoDto>>(filteredPermisos);
        }
    }
}