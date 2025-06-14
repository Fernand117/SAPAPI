using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Empleados.Queries.SearchEmpleados
{
    public class SearchEmpleadosQuery : IRequest<IEnumerable<EmpleadoDto>>
    {
        public string SearchTerm { get; set; }
    }
} 