using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.InventarioVendedores.Queries.GetInventarioByProducto
{
    public class GetInventarioByProductoQueryHandler : IRequestHandler<GetInventarioByProductoQuery, IEnumerable<InventarioVendedorDto>>
    {
        private readonly IInventarioVendedorRepository _inventarioVendedorRepository;
        private readonly IMapper _mapper;

        public GetInventarioByProductoQueryHandler(IInventarioVendedorRepository inventarioVendedorRepository, IMapper mapper)
        {
            _inventarioVendedorRepository = inventarioVendedorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventarioVendedorDto>> Handle(GetInventarioByProductoQuery request, CancellationToken cancellationToken)
        {
            var inventario = await _inventarioVendedorRepository.GetByProductoIdAsync(request.ProductoId);
            return _mapper.Map<IEnumerable<InventarioVendedorDto>>(inventario);
        }
    }
} 