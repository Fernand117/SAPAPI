using MediatR;

namespace SAP.Application.Features.Empleados.Commands.DeleteEmpleado
{
    public class DeleteEmpleadoCommand : IRequest<bool>
    {
        public int EmpleadoId { get; set; }
    }
} 