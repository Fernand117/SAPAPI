using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Productos.Queries.GetProductoById
{
    public class GetProductoByIdQueryHandler : IRequestHandler<GetProductoByIdQuery, ProductoDetalleDto>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public GetProductoByIdQueryHandler(
            IProductoRepository productoRepository,
            IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<ProductoDetalleDto> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
        {
            var producto = await _productoRepository.GetByIdAsync(request.ProductoId);
            return _mapper.Map<ProductoDetalleDto>(producto);
        }
    }
} 