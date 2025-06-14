using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Categorias.Queries.GetCategoriasByNombre
{
    public class GetCategoriasByNombreQuery : IRequest<IEnumerable<CategoriaDto>>
    {
        public required string Nombre { get; set; }
        public bool SoloActivas { get; set; } = true;
    }
} 