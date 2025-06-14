using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Sucursales.Queries.SearchSucursales
{
    public class SearchSucursalesQuery : IRequest<IEnumerable<SucursalDto>>
    {
        public string? SearchTerm { get; set; }
    }
}