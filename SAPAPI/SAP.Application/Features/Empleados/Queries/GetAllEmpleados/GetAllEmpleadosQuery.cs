using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Empleados.Queries.GetAllEmpleados
{
    public class GetAllEmpleadosQuery : IRequest<IEnumerable<EmpleadoDto>>
    {
    }
} 