using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Productos.Queries.GetAllProductos
{
    public class GetAllProductosQueryHandler : IRequestHandler<GetAllProductosQuery, IEnumerable<ProductoDto>>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public GetAllProductosQueryHandler(
            IProductoRepository productoRepository,
            IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductoDto>> Handle(GetAllProductosQuery request, CancellationToken cancellationToken)
        {
            var productos = await _productoRepository.GetAllAsync();
            if (request.SoloActivos)
            {
                productos = productos.Where(p => p.Activo);
            }
            return _mapper.Map<IEnumerable<ProductoDto>>(productos);
        }
    }
} 