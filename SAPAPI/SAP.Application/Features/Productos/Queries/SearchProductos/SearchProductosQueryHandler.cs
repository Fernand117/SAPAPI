using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Productos.Queries.SearchProductos
{
    public class SearchProductosQueryHandler : IRequestHandler<SearchProductosQuery, IEnumerable<ProductoDto>>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public SearchProductosQueryHandler(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductoDto>> Handle(SearchProductosQuery request, CancellationToken cancellationToken)
        {
            var productos = await _productoRepository.GetAllAsync();
            var searchTerm = request.SearchTerm.ToLower();

            var productosFiltrados = productos.Where(p =>
                p.Nombre.ToLower().Contains(searchTerm) ||
                p.Codigo.ToLower().Contains(searchTerm) ||
                p.Descripcion.ToLower().Contains(searchTerm));

            if (request.SoloActivos)
            {
                productosFiltrados = productosFiltrados.Where(p => p.Activo);
            }

            return _mapper.Map<IEnumerable<ProductoDto>>(productosFiltrados);
        }
    }
} 