using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Empleados.Queries.GetAllEmpleados
{
    public class GetAllEmpleadosQueryHandler : IRequestHandler<GetAllEmpleadosQuery, IEnumerable<EmpleadoDto>>
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IMapper _mapper;

        public GetAllEmpleadosQueryHandler(
            IEmpleadoRepository empleadoRepository,
            IMapper mapper)
        {
            _empleadoRepository = empleadoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmpleadoDto>> Handle(GetAllEmpleadosQuery request, CancellationToken cancellationToken)
        {
            var empleados = await _empleadoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmpleadoDto>>(empleados);
        }
    }
} 