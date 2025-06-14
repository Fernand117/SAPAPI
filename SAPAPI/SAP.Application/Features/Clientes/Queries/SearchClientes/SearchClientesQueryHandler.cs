using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Clientes.Queries.SearchClientes
{
    public class SearchClientesQueryHandler : IRequestHandler<SearchClientesQuery, IEnumerable<ClienteDto>>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public SearchClientesQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDto>> Handle(SearchClientesQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository.GetAllAsync();
            var clientesFiltrados = clientes.Where(c => 
                c.Nombre.Contains(request.SearchTerm, System.StringComparison.OrdinalIgnoreCase) ||
                c.Apellido.Contains(request.SearchTerm, System.StringComparison.OrdinalIgnoreCase) ||
                c.Email.Contains(request.SearchTerm, System.StringComparison.OrdinalIgnoreCase));
            
            return _mapper.Map<IEnumerable<ClienteDto>>(clientesFiltrados);
        }
    }
} 