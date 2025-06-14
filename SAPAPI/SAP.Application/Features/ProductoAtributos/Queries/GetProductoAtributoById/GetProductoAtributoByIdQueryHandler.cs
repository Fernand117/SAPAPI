using MediatR;
using Microsoft.EntityFrameworkCore;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.ProductoAtributos.Queries.GetProductoAtributoById
{
    public class GetProductoAtributoByIdQueryHandler : IRequestHandler<GetProductoAtributoByIdQuery, ProductoAtributoDto>
    {
        private readonly IGenericRepository<Domain.Entities.ProductoAtributo> _repository;

        public GetProductoAtributoByIdQueryHandler(IGenericRepository<Domain.Entities.ProductoAtributo> repository)
        {
            _repository = repository;
        }

        public async Task<ProductoAtributoDto> Handle(GetProductoAtributoByIdQuery request, CancellationToken cancellationToken)
        {
            var productoAtributo = await _repository.GetByIdAsync(request.ProductoAtributoId);
            if (productoAtributo == null)
                return null;

            return new ProductoAtributoDto
            {
                ProductoAtributoId = productoAtributo.ProductoAtributoId,
                ProductoId = productoAtributo.ProductoId,
                AtributoId = productoAtributo.AtributoId,
                NombreProducto = productoAtributo.Producto?.Nombre,
                NombreAtributo = productoAtributo.Atributo?.Nombre
            };
        }
    }
} 