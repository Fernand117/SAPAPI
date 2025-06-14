using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Empleados.Queries.GetEmpleadosActivos
{
    public class GetEmpleadosActivosQuery : IRequest<IEnumerable<EmpleadoDto>>
    {
    }
} 