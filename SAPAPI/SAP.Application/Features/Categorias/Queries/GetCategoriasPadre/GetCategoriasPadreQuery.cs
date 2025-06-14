using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Categorias.Queries.GetCategoriasPadre
{
    public class GetCategoriasPadreQuery : IRequest<IEnumerable<CategoriaDto>>
    {
        public bool SoloActivas { get; set; } = true;
    }
} 