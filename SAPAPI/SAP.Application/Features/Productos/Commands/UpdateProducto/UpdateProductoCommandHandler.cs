using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Productos.Commands.UpdateProducto
{
    public class UpdateProductoCommandHandler : IRequestHandler<UpdateProductoCommand, ProductoDto>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public UpdateProductoCommandHandler(
            IProductoRepository productoRepository,
            IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<ProductoDto> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            var producto = await _productoRepository.GetByIdAsync(request.Producto.ProductoId);
            if (producto == null)
                return null;

            producto.Codigo = request.Producto.Codigo;
            producto.Nombre = request.Producto.Nombre;
            producto.Descripcion = request.Producto.Descripcion;
            producto.PrecioVenta = request.Producto.PrecioVenta;
            producto.PrecioCompra = request.Producto.PrecioCompra;
            producto.Activo = request.Producto.Activo;
            producto.CategoriaId = request.Producto.CategoriaId;

            await _productoRepository.UpdateAsync(producto);

            // Actualizar atributos si existen
            if (request.Producto.Atributos != null)
            {
                foreach (var atributoDto in request.Producto.Atributos)
                {
                    await _productoRepository.UpdateAtributoAsync(
                        request.Producto.ProductoId,
                        atributoDto.AtributoId,
                        atributoDto.Valor);
                }
            }

            return _mapper.Map<ProductoDto>(producto);
        }
    }
} 