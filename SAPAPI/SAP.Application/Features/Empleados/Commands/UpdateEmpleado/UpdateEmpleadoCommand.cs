using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Empleados.Commands.UpdateEmpleado
{
    public class UpdateEmpleadoCommand : IRequest<EmpleadoDto>
    {
        public required UpdateEmpleadoDto Empleado { get; set; }
    }
} 