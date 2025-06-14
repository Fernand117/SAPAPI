using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Productos.Queries.GetProductosByCategoria
{
    public class GetProductosByCategoriaQueryHandler : IRequestHandler<GetProductosByCategoriaQuery, IEnumerable<ProductoDto>>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public GetProductosByCategoriaQueryHandler(
            IProductoRepository productoRepository,
            IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductoDto>> Handle(GetProductosByCategoriaQuery request, CancellationToken cancellationToken)
        {
            var productos = await _productoRepository.GetByCategoriaAsync(request.CategoriaId);
            return _mapper.Map<IEnumerable<ProductoDto>>(productos);
        }
    }
} 