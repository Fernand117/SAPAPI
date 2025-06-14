using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Empleados.Commands.UpdateEmpleado
{
    public class UpdateEmpleadoCommandHandler : IRequestHandler<UpdateEmpleadoCommand, EmpleadoDto>
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IMapper _mapper;

        public UpdateEmpleadoCommandHandler(
            IEmpleadoRepository empleadoRepository,
            IMapper mapper)
        {
            _empleadoRepository = empleadoRepository;
            _mapper = mapper;
        }

        public async Task<EmpleadoDto> Handle(UpdateEmpleadoCommand request, CancellationToken cancellationToken)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(request.Empleado.EmpleadoId);
            if (empleado == null)
                return null;

            empleado.Nombre = request.Empleado.Nombre;
            empleado.Apellido = request.Empleado.Apellido;
            empleado.Direccion = request.Empleado.Direccion;
            empleado.Telefono = request.Empleado.Telefono;
            empleado.Email = request.Empleado.Email;
            empleado.SucursalId = request.Empleado.SucursalId;
            empleado.Cargo = request.Empleado.Cargo;
            empleado.Salario = request.Empleado.Salario;
            empleado.Activo = request.Empleado.Activo;

            await _empleadoRepository.UpdateAsync(empleado);
            return _mapper.Map<EmpleadoDto>(empleado);
        }
    }
} 