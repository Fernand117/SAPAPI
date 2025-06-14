using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Sucursales.Queries.SearchSucursales
{
    public class SearchSucursalesQueryHandler : IRequestHandler<SearchSucursalesQuery, IEnumerable<SucursalDto>>
    {
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IMapper _mapper;

        public SearchSucursalesQueryHandler(ISucursalRepository sucursalRepository, IMapper mapper)
        {
            _sucursalRepository = sucursalRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SucursalDto>> Handle(SearchSucursalesQuery request, CancellationToken cancellationToken)
        {
            var sucursales = await _sucursalRepository.GetAllAsync();
            var sucursalesFiltradas = sucursales.Where(s => 
                s.Nombre.Contains(request.SearchTerm, System.StringComparison.OrdinalIgnoreCase) ||
                s.Direccion.Contains(request.SearchTerm, System.StringComparison.OrdinalIgnoreCase) ||
                s.Email.Contains(request.SearchTerm, System.StringComparison.OrdinalIgnoreCase));
            
            return _mapper.Map<IEnumerable<SucursalDto>>(sucursalesFiltradas);
        }
    }
} 