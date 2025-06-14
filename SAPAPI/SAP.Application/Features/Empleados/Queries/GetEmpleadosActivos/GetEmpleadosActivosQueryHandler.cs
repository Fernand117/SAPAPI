using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Empleados.Queries.GetEmpleadosActivos
{
    public class GetEmpleadosActivosQueryHandler : IRequestHandler<GetEmpleadosActivosQuery, IEnumerable<EmpleadoDto>>
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IMapper _mapper;

        public GetEmpleadosActivosQueryHandler(IEmpleadoRepository empleadoRepository, IMapper mapper)
        {
            _empleadoRepository = empleadoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmpleadoDto>> Handle(GetEmpleadosActivosQuery request, CancellationToken cancellationToken)
        {
            var empleados = await _empleadoRepository.GetAllAsync();
            var empleadosActivos = empleados.Where(e => e.Activo);
            return _mapper.Map<IEnumerable<EmpleadoDto>>(empleadosActivos);
        }
    }
} 