using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Empleados.Commands.DeleteEmpleado
{
    public class DeleteEmpleadoCommandHandler : IRequestHandler<DeleteEmpleadoCommand, bool>
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public DeleteEmpleadoCommandHandler(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task<bool> Handle(DeleteEmpleadoCommand request, CancellationToken cancellationToken)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(request.EmpleadoId);
            if (empleado == null)
                return false;

            return await _empleadoRepository.DeleteAsync(empleado);
        }
    }
} 