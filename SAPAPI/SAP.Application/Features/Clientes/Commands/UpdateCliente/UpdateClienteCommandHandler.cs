using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, ClienteDto>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public UpdateClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDto> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Cliente.ClienteId);
            if (cliente == null)
                return null;

            cliente.Nombre = request.Cliente.Nombre;
            cliente.Apellido = request.Cliente.Apellido;
            cliente.Direccion = request.Cliente.Direccion;
            cliente.Telefono = request.Cliente.Telefono;
            cliente.Email = request.Cliente.Email;
            cliente.Activo = request.Cliente.Activo;

            await _clienteRepository.UpdateAsync(cliente);
            return _mapper.Map<ClienteDto>(cliente);
        }
    }
} 