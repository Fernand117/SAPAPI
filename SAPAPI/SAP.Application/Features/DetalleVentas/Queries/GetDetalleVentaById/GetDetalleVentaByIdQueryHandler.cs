using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.DetalleVentas.Queries.GetDetalleVentaById
{
    public class GetDetalleVentaByIdQueryHandler : IRequestHandler<GetDetalleVentaByIdQuery, DetalleVentaDetalleDto>
    {
        private readonly IDetalleVentaRepository _detalleVentaRepository;
        private readonly IMapper _mapper;

        public GetDetalleVentaByIdQueryHandler(IDetalleVentaRepository detalleVentaRepository, IMapper mapper)
        {
            _detalleVentaRepository = detalleVentaRepository;
            _mapper = mapper;
        }

        public async Task<DetalleVentaDetalleDto> Handle(GetDetalleVentaByIdQuery request, CancellationToken cancellationToken)
        {
            var detalleVenta = await _detalleVentaRepository.GetByIdAsync(request.DetalleVentaId);
            return _mapper.Map<DetalleVentaDetalleDto>(detalleVenta);
        }
    }
} 