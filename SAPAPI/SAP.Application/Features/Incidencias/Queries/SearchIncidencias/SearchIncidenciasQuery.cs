using MediatR;
using SAP.Application.DTOs;
using System.Collections.Generic;

namespace SAP.Application.Features.Incidencias.Queries.SearchIncidencias
{
    public class SearchIncidenciasQuery : IRequest<IEnumerable<IncidenciaDto>>
    {
        public string SearchTerm { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
} 