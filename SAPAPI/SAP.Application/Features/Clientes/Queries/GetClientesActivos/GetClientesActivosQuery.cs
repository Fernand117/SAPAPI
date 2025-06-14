using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Clientes.Queries.GetClientesActivos
{
    public class GetClientesActivosQuery : IRequest<IEnumerable<ClienteDto>>
    {
    }
} 