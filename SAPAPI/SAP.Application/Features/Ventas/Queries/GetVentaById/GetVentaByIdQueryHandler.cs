using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Ventas.Queries.GetVentaById
{
    public class GetVentaByIdQueryHandler : IRequestHandler<GetVentaByIdQuery, VentaDto>
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IMapper _mapper;

        public GetVentaByIdQueryHandler(IVentaRepository ventaRepository, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _mapper = mapper;
        }

        public async Task<VentaDto> Handle(GetVentaByIdQuery request, CancellationToken cancellationToken)
        {
            var venta = await _ventaRepository.GetVentaWithDetallesAsync(request.VentaId);
            return venta != null ? _mapper.Map<VentaDto>(venta) : null;
        }
    }
} 