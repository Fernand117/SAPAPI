using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;
using SAP.Domain.Entities;

namespace SAP.Application.Features.UnidadMoviles.Commands.UpdateUnidadMovil
{
    public class UpdateUnidadMovilCommandHandler : IRequestHandler<UpdateUnidadMovilCommand, UnidadMovilDto>
    {
        private readonly IGenericRepository<UnidadMovil> _repository;
        private readonly IMapper _mapper;

        public UpdateUnidadMovilCommandHandler(IGenericRepository<UnidadMovil> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UnidadMovilDto> Handle(UpdateUnidadMovilCommand request, CancellationToken cancellationToken)
        {
            var unidadMovil = await _repository.GetByIdAsync(request.UnidadMovilId);
            if (unidadMovil == null)
                throw new Exception($"No se encontró la unidad móvil con ID {request.UnidadMovilId}");

            unidadMovil.Placa = request.Placa;
            unidadMovil.Marca = request.Marca;
            unidadMovil.Modelo = request.Modelo;
            unidadMovil.Anio = request.Anio;
            unidadMovil.Color = request.Color;
            unidadMovil.Estado = request.Estado;
            unidadMovil.Tipo = request.Tipo;
            unidadMovil.SucursalId = request.SucursalId;

            await _repository.UpdateAsync(unidadMovil);
            return _mapper.Map<UnidadMovilDto>(unidadMovil);
        }
    }
} 