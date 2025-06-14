using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Ventas.Queries.GetVentasByCliente
{
    public class GetVentasByClienteQueryHandler : IRequestHandler<GetVentasByClienteQuery, IEnumerable<VentaDto>>
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IMapper _mapper;

        public GetVentasByClienteQueryHandler(IVentaRepository ventaRepository, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VentaDto>> Handle(GetVentasByClienteQuery request, CancellationToken cancellationToken)
        {
            var ventas = await _ventaRepository.GetVentasByClienteAsync(request.ClienteId);
            return _mapper.Map<IEnumerable<VentaDto>>(ventas);
        }
    }
} 