using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Categorias.Queries.GetSubCategorias
{
    public class GetSubCategoriasQuery : IRequest<IEnumerable<CategoriaDto>>
    {
        public int CategoriaPadreId { get; set; }
        public bool SoloActivas { get; set; } = true;
    }
} 