using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Clientes.Queries.GetClienteById
{
    public class GetClienteByIdQuery : IRequest<ClienteDto>
    {
        public int ClienteId { get; set; }
    }
} 