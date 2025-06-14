using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Categorias.Commands.UpdateCategoria
{
    public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, CategoriaDto>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public UpdateCategoriaCommandHandler(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<CategoriaDto> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(request.Categoria.CategoriaId);
            if (categoria == null)
                throw new Exception("Categoría no encontrada");

            categoria.Nombre = request.Categoria.Nombre;
            categoria.Descripcion = request.Categoria.Descripcion;

            await _categoriaRepository.UpdateAsync(categoria);
            return _mapper.Map<CategoriaDto>(categoria);
        }
    }
} 