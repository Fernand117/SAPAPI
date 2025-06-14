using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Ventas.Queries.GetVentasByVendedor
{
    public class GetVentasByVendedorQueryHandler : IRequestHandler<GetVentasByVendedorQuery, IEnumerable<VentaDto>>
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IMapper _mapper;

        public GetVentasByVendedorQueryHandler(IVentaRepository ventaRepository, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VentaDto>> Handle(GetVentasByVendedorQuery request, CancellationToken cancellationToken)
        {
            var ventas = await _ventaRepository.GetVentasByVendedorAsync(request.UsuarioId);
            return _mapper.Map<IEnumerable<VentaDto>>(ventas);
        }
    }
} 