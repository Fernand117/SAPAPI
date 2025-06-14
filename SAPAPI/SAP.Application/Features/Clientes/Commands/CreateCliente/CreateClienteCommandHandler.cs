using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, ClienteDto>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public CreateClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDto> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = _mapper.Map<Cliente>(request.Cliente);
            cliente.FechaRegistro = DateTime.UtcNow;
            cliente.Activo = true;
            var clienteCreado = await _clienteRepository.AddAsync(cliente);
            return _mapper.Map<ClienteDto>(clienteCreado);
        }
    }
} 