using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Empleados.Queries.GetEmpleadoById
{
    public class GetEmpleadoByIdQueryHandler : IRequestHandler<GetEmpleadoByIdQuery, EmpleadoDto>
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IMapper _mapper;

        public GetEmpleadoByIdQueryHandler(
            IEmpleadoRepository empleadoRepository,
            IMapper mapper)
        {
            _empleadoRepository = empleadoRepository;
            _mapper = mapper;
        }

        public async Task<EmpleadoDto> Handle(GetEmpleadoByIdQuery request, CancellationToken cancellationToken)
        {
            var empleado = await _empleadoRepository.GetEmpleadoWithUsuarioAsync(request.EmpleadoId);
            return empleado != null ? _mapper.Map<EmpleadoDto>(empleado) : null;
        }
    }
} 