using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Clientes.Queries.GetAllClientes
{
    public class GetAllClientesQuery : IRequest<IEnumerable<ClienteDto>>
    {
    }
} 