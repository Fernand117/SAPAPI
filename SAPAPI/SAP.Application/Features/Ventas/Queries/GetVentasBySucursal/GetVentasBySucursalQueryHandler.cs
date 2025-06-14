using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Ventas.Queries.GetVentasBySucursal
{
    public class GetVentasBySucursalQueryHandler : IRequestHandler<GetVentasBySucursalQuery, IEnumerable<VentaDto>>
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IMapper _mapper;

        public GetVentasBySucursalQueryHandler(IVentaRepository ventaRepository, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VentaDto>> Handle(GetVentasBySucursalQuery request, CancellationToken cancellationToken)
        {
            var ventas = await _ventaRepository.GetVentasBySucursalAsync(request.SucursalId);
            return _mapper.Map<IEnumerable<VentaDto>>(ventas);
        }
    }
} 