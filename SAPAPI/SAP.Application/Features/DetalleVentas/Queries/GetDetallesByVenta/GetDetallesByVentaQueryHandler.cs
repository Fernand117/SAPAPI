using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.DetalleVentas.Queries.GetDetallesByVenta
{
    public class GetDetallesByVentaQueryHandler : IRequestHandler<GetDetallesByVentaQuery, IEnumerable<DetalleVentaDto>>
    {
        private readonly IDetalleVentaRepository _detalleVentaRepository;
        private readonly IMapper _mapper;

        public GetDetallesByVentaQueryHandler(IDetalleVentaRepository detalleVentaRepository, IMapper mapper)
        {
            _detalleVentaRepository = detalleVentaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DetalleVentaDto>> Handle(GetDetallesByVentaQuery request, CancellationToken cancellationToken)
        {
            var detalles = await _detalleVentaRepository.GetByVentaIdAsync(request.VentaId);
            return _mapper.Map<IEnumerable<DetalleVentaDto>>(detalles);
        }
    }
} 