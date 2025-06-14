using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.ProductoAtributos.Commands.UpdateProductoAtributo
{
    public class UpdateProductoAtributoCommandHandler : IRequestHandler<UpdateProductoAtributoCommand, ProductoAtributoDto>
    {
        private readonly IGenericRepository<ProductoAtributo> _repository;

        public UpdateProductoAtributoCommandHandler(IGenericRepository<ProductoAtributo> repository)
        {
            _repository = repository;
        }

        public async Task<ProductoAtributoDto> Handle(UpdateProductoAtributoCommand request, CancellationToken cancellationToken)
        {
            var productoAtributo = await _repository.GetByIdAsync(request.ProductoAtributoId);
            if (productoAtributo == null)
                return null;

            productoAtributo.ProductoId = request.ProductoId;
            productoAtributo.AtributoId = request.AtributoId;

            await _repository.UpdateAsync(productoAtributo);

            return new ProductoAtributoDto
            {
                ProductoAtributoId = productoAtributo.ProductoAtributoId,
                ProductoId = productoAtributo.ProductoId,
                AtributoId = productoAtributo.AtributoId
            };
        }
    }
} 