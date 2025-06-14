using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;
using SAP.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.CategoriaProductos.Queries.GetCategoriaProductoById
{
    public class GetCategoriaProductoByIdQueryHandler : IRequestHandler<GetCategoriaProductoByIdQuery, CategoriaProductoDto>
    {
        private readonly IGenericRepository<CategoriaProducto> _repository;
        private readonly IMapper _mapper;

        public GetCategoriaProductoByIdQueryHandler(IGenericRepository<CategoriaProducto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoriaProductoDto> Handle(GetCategoriaProductoByIdQuery request, CancellationToken cancellationToken)
        {
            var categoriaProducto = await _repository.GetByIdAsync(request.CategoriaProductoId);
            if (categoriaProducto == null)
                throw new Exception($"No se encontró la categoría de producto con ID {request.CategoriaProductoId}");

            return _mapper.Map<CategoriaProductoDto>(categoriaProducto);
        }
    }
} 