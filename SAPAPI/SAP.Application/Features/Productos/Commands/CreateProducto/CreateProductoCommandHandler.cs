using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Productos.Commands.CreateProducto
{
    public class CreateProductoCommandHandler : IRequestHandler<CreateProductoCommand, ProductoDto>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public CreateProductoCommandHandler(
            IProductoRepository productoRepository,
            IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<ProductoDto> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            var producto = _mapper.Map<Producto>(request.Producto);
            producto.Activo = true;

            var productoCreado = await _productoRepository.AddAsync(producto);

            // Agregar atributos si existen
            if (request.Producto.Atributos != null)
            {
                foreach (var atributoDto in request.Producto.Atributos)
                {
                    var productoAtributo = new ProductoAtributo
                    {
                        ProductoId = productoCreado.ProductoId,
                        AtributoId = atributoDto.AtributoId
                    };
                    await _productoRepository.AddAtributoAsync(productoAtributo, atributoDto.Valor);
                }
            }

            return _mapper.Map<ProductoDto>(productoCreado);
        }
    }
} 