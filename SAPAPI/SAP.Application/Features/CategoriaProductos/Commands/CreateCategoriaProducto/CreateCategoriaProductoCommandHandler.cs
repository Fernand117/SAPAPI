using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;
using SAP.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.CategoriaProductos.Commands.CreateCategoriaProducto
{
    public class CreateCategoriaProductoCommandHandler : IRequestHandler<CreateCategoriaProductoCommand, CategoriaProductoDto>
    {
        private readonly IGenericRepository<CategoriaProducto> _repository;
        private readonly IMapper _mapper;

        public CreateCategoriaProductoCommandHandler(IGenericRepository<CategoriaProducto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoriaProductoDto> Handle(CreateCategoriaProductoCommand request, CancellationToken cancellationToken)
        {
            var categoriaProducto = new CategoriaProducto
            {
                CategoriaId = request.CategoriaId,
                ProductoId = request.ProductoId
            };

            await _repository.AddAsync(categoriaProducto);
            return _mapper.Map<CategoriaProductoDto>(categoriaProducto);
        }
    }
} 