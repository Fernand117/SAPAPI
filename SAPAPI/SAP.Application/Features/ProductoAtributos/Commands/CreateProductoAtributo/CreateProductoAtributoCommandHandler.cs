using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.ProductoAtributos.Commands.CreateProductoAtributo
{
    public class CreateProductoAtributoCommandHandler : IRequestHandler<CreateProductoAtributoCommand, ProductoAtributoDto>
    {
        private readonly IGenericRepository<ProductoAtributo> _repository;

        public CreateProductoAtributoCommandHandler(IGenericRepository<ProductoAtributo> repository)
        {
            _repository = repository;
        }

        public async Task<ProductoAtributoDto> Handle(CreateProductoAtributoCommand request, CancellationToken cancellationToken)
        {
            var productoAtributo = new ProductoAtributo
            {
                ProductoId = request.ProductoId,
                AtributoId = request.AtributoId
            };

            await _repository.AddAsync(productoAtributo);

            return new ProductoAtributoDto
            {
                ProductoAtributoId = productoAtributo.ProductoAtributoId,
                ProductoId = productoAtributo.ProductoId,
                AtributoId = productoAtributo.AtributoId
            };
        }
    }
} 