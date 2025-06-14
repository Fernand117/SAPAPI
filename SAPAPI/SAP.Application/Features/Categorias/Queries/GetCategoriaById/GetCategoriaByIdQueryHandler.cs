using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;
using SAP.Application.Exceptions; // Add a custom exception namespace  

namespace SAP.Application.Features.Categorias.Queries.GetCategoriaById
{
    public class GetCategoriaByIdQueryHandler : IRequestHandler<GetCategoriaByIdQuery, CategoriaDetalleDto>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public GetCategoriaByIdQueryHandler(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<CategoriaDetalleDto> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(request.CategoriaId);
            if (categoria == null) throw new NotFoundException("Categoría no encontrada"); // Replace System.Exception with a custom exception  

            var categoriaDto = _mapper.Map<CategoriaDetalleDto>(categoria);

            // Cargar subcategorías  
            var subCategorias = await _categoriaRepository.GetSubCategoriasAsync(request.CategoriaId);
            categoriaDto.SubCategorias = _mapper.Map<ICollection<CategoriaDto>>(subCategorias);

            // Cargar productos  
            var productos = await _categoriaRepository.GetProductosAsync(request.CategoriaId);
            categoriaDto.Productos = _mapper.Map<ICollection<ProductoDto>>(productos);

            return categoriaDto;
        }
    }
}

// Add a custom exception class in a separate file or namespace  
namespace SAP.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}