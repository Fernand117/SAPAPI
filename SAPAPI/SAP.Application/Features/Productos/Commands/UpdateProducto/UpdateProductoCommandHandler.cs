using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
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
                throw new Exception("Producto no encontrado");

            producto.Codigo = request.Producto.Codigo;
            producto.Nombre = request.Producto.Nombre;
            producto.Descripcion = request.Producto.Descripcion ?? producto.Descripcion;
            producto.CategoriaId = request.Producto.CategoriaId;
            producto.PrecioVenta = request.Producto.Precio;
            producto.Activo = request.Producto.Activo;

            await _productoRepository.UpdateAsync(producto);
            return _mapper.Map<ProductoDto>(producto);
        }
    }
} 