using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Categorias.Queries.GetAllCategorias
{
    public class GetAllCategoriasQuery : IRequest<IEnumerable<CategoriaDto>>
    {
        public bool SoloActivas { get; set; } = true;
        public bool IncluirSubCategorias { get; set; } = false;
        public bool IncluirProductos { get; set; } = false;
    }
} 