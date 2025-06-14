using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommand : IRequest<ClienteDto>
    {
        public UpdateClienteDto Cliente { get; set; }
    }
} 