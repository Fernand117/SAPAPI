using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;
using SAP.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.CategoriaProductos.Commands.UpdateCategoriaProducto
{
    public class UpdateCategoriaProductoCommandHandler : IRequestHandler<UpdateCategoriaProductoCommand, CategoriaProductoDto>
    {
        private readonly IGenericRepository<CategoriaProducto> _repository;
        private readonly IMapper _mapper;

        public UpdateCategoriaProductoCommandHandler(IGenericRepository<CategoriaProducto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoriaProductoDto> Handle(UpdateCategoriaProductoCommand request, CancellationToken cancellationToken)
        {
            var categoriaProducto = await _repository.GetByIdAsync(request.CategoriaProductoId);
            if (categoriaProducto == null)
                throw new Exception($"No se encontró la categoría de producto con ID {request.CategoriaProductoId}");

            categoriaProducto.CategoriaId = request.CategoriaId;
            categoriaProducto.ProductoId = request.ProductoId;

            await _repository.UpdateAsync(categoriaProducto);
            return _mapper.Map<CategoriaProductoDto>(categoriaProducto);
        }
    }
} 