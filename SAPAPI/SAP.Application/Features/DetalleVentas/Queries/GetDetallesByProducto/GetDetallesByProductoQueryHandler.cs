using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.DetalleVentas.Queries.GetDetallesByProducto
{
    public class GetDetallesByProductoQueryHandler : IRequestHandler<GetDetallesByProductoQuery, IEnumerable<DetalleVentaDto>>
    {
        private readonly IDetalleVentaRepository _detalleVentaRepository;
        private readonly IMapper _mapper;

        public GetDetallesByProductoQueryHandler(IDetalleVentaRepository detalleVentaRepository, IMapper mapper)
        {
            _detalleVentaRepository = detalleVentaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DetalleVentaDto>> Handle(GetDetallesByProductoQuery request, CancellationToken cancellationToken)
        {
            var detalles = await _detalleVentaRepository.GetByProductoIdAsync(request.ProductoId);
            return _mapper.Map<IEnumerable<DetalleVentaDto>>(detalles);
        }
    }
} 