using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Empleados.Commands.CreateEmpleado
{
    public class CreateEmpleadoCommand : IRequest<EmpleadoDto>
    {
        public required CreateEmpleadoDto Empleado { get; set; }
    }
} 