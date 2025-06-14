using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.InventarioVendedores.Queries.GetInventarioByEmpleado
{
    public class GetInventarioByEmpleadoQueryHandler : IRequestHandler<GetInventarioByEmpleadoQuery, IEnumerable<InventarioVendedorDto>>
    {
        private readonly IInventarioVendedorRepository _inventarioVendedorRepository;
        private readonly IMapper _mapper;

        public GetInventarioByEmpleadoQueryHandler(IInventarioVendedorRepository inventarioVendedorRepository, IMapper mapper)
        {
            _inventarioVendedorRepository = inventarioVendedorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventarioVendedorDto>> Handle(GetInventarioByEmpleadoQuery request, CancellationToken cancellationToken)
        {
            var inventario = await _inventarioVendedorRepository.GetByEmpleadoIdAsync(request.EmpleadoId);
            return _mapper.Map<IEnumerable<InventarioVendedorDto>>(inventario);
        }
    }
} 