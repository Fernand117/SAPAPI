using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Categorias.Commands.CreateCategoria
{
    public class CreateCategoriaCommandHandler : IRequestHandler<CreateCategoriaCommand, CategoriaDto>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CreateCategoriaCommandHandler(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<CategoriaDto> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = _mapper.Map<Categoria>(request.Categoria);
            categoria.FechaCreacion = DateTime.UtcNow;
            categoria.Activa = true;
            var categoriaCreada = await _categoriaRepository.AddAsync(categoria);
            return _mapper.Map<CategoriaDto>(categoriaCreada);
        }
    }
} 