using MediatR;
using SAP.Application.DTOs;
using System.Collections.Generic;

namespace SAP.Application.Features.UnidadMoviles.Queries.SearchUnidadMoviles
{
    public class SearchUnidadMovilesQuery : IRequest<IEnumerable<UnidadMovilDto>>
    {
        public string SearchTerm { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
} 