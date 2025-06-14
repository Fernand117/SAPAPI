using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Empleados.Queries.GetEmpleadosBySucursal
{
    public class GetEmpleadosBySucursalQuery : IRequest<IEnumerable<EmpleadoDto>>
    {
        public int SucursalId { get; set; }
    }
} 