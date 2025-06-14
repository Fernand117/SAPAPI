using MediatR;

namespace SAP.Application.Features.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommand : IRequest<bool>
    {
        public int ClienteId { get; set; }
    }
} 