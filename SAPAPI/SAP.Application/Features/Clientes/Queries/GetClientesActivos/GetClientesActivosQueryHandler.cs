using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Clientes.Queries.GetClientesActivos
{
    public class GetClientesActivosQueryHandler : IRequestHandler<GetClientesActivosQuery, IEnumerable<ClienteDto>>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public GetClientesActivosQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDto>> Handle(GetClientesActivosQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository.GetAllAsync();
            var clientesActivos = clientes.Where(c => c.Activo);
            return _mapper.Map<IEnumerable<ClienteDto>>(clientesActivos);
        }
    }
} 