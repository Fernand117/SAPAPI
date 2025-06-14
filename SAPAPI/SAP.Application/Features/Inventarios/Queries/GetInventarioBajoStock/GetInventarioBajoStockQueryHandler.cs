using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Application.Interfaces;

namespace SAP.Application.Features.Inventarios.Queries.GetInventarioBajoStock
{
    public class GetInventarioBajoStockQueryHandler : IRequestHandler<GetInventarioBajoStockQuery, IEnumerable<InventarioDto>>
    {
        private readonly IInventarioRepository _inventarioRepository;
        private readonly IMapper _mapper;

        public GetInventarioBajoStockQueryHandler(IInventarioRepository inventarioRepository, IMapper mapper)
        {
            _inventarioRepository = inventarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventarioDto>> Handle(GetInventarioBajoStockQuery request, CancellationToken cancellationToken)
        {
            var inventarios = await _inventarioRepository.GetInventarioBajoStockAsync(request.CantidadMinima);
            return _mapper.Map<IEnumerable<InventarioDto>>(inventarios);
        }
    }
} 