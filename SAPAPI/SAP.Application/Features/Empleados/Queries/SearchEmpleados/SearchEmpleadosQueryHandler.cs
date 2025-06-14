using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Empleados.Queries.SearchEmpleados
{
    public class SearchEmpleadosQueryHandler : IRequestHandler<SearchEmpleadosQuery, IEnumerable<EmpleadoDto>>
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IMapper _mapper;

        public SearchEmpleadosQueryHandler(IEmpleadoRepository empleadoRepository, IMapper mapper)
        {
            _empleadoRepository = empleadoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmpleadoDto>> Handle(SearchEmpleadosQuery request, CancellationToken cancellationToken)
        {
            var empleados = await _empleadoRepository.GetAllAsync();
            var empleadosFiltrados = empleados.Where(e => 
                e.Nombre.Contains(request.SearchTerm, System.StringComparison.OrdinalIgnoreCase) ||
                e.Apellido.Contains(request.SearchTerm, System.StringComparison.OrdinalIgnoreCase) ||
                e.Email.Contains(request.SearchTerm, System.StringComparison.OrdinalIgnoreCase) ||
                e.Cargo.Contains(request.SearchTerm, System.StringComparison.OrdinalIgnoreCase));
            
            return _mapper.Map<IEnumerable<EmpleadoDto>>(empleadosFiltrados);
        }
    }
} 