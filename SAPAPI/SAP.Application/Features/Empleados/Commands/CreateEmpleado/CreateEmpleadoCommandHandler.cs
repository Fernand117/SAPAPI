using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Empleados.Commands.CreateEmpleado
{
    public class CreateEmpleadoCommandHandler : IRequestHandler<CreateEmpleadoCommand, EmpleadoDto>
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IMapper _mapper;

        public CreateEmpleadoCommandHandler(IEmpleadoRepository empleadoRepository, IMapper mapper)
        {
            _empleadoRepository = empleadoRepository;
            _mapper = mapper;
        }

        public async Task<EmpleadoDto> Handle(CreateEmpleadoCommand request, CancellationToken cancellationToken)
        {
            var empleado = _mapper.Map<Empleado>(request.Empleado);
            empleado.FechaContratacion = DateTime.UtcNow;
            empleado.Activo = true;
            var empleadoCreado = await _empleadoRepository.AddAsync(empleado);
            return _mapper.Map<EmpleadoDto>(empleadoCreado);
        }
    }
} 