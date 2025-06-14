using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Clientes.Queries.SearchClientes
{
    public class SearchClientesQuery : IRequest<IEnumerable<ClienteDto>>
    {
        public string SearchTerm { get; set; }
    }
} 