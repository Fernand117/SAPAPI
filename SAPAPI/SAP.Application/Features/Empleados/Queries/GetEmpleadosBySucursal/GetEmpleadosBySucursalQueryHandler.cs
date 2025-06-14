using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Empleados.Queries.GetEmpleadosBySucursal
{
    public class GetEmpleadosBySucursalQueryHandler : IRequestHandler<GetEmpleadosBySucursalQuery, IEnumerable<EmpleadoDto>>
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IMapper _mapper;

        public GetEmpleadosBySucursalQueryHandler(
            IEmpleadoRepository empleadoRepository,
            IMapper mapper)
        {
            _empleadoRepository = empleadoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmpleadoDto>> Handle(GetEmpleadosBySucursalQuery request, CancellationToken cancellationToken)
        {
            var empleados = await _empleadoRepository.GetAllAsync();
            var empleadosPorSucursal = empleados.Where(e => e.SucursalId == request.SucursalId);
            return _mapper.Map<IEnumerable<EmpleadoDto>>(empleadosPorSucursal);
        }
    }
} 