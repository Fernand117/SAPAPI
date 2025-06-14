using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommand : IRequest<ClienteDto>
    {
        public required CreateClienteDto Cliente { get; set; }
    }
} 