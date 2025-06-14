using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Application.Interfaces;
using SAP.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.UnidadMoviles.Commands.CreateUnidadMovil
{
    public class CreateUnidadMovilCommandHandler : IRequestHandler<CreateUnidadMovilCommand, UnidadMovilDto>
    {
        private readonly IGenericRepository<UnidadMovil> _repository;
        private readonly IMapper _mapper;

        public CreateUnidadMovilCommandHandler(IGenericRepository<UnidadMovil> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UnidadMovilDto> Handle(CreateUnidadMovilCommand request, CancellationToken cancellationToken)
        {
            var unidadMovil = new UnidadMovil
            {
                Placa = request.Placa,
                Marca = request.Marca,
                Modelo = request.Modelo,
                Anio = request.Anio,
                Color = request.Color,
                Estado = request.Estado,
                Tipo = request.Tipo,
                SucursalId = request.SucursalId
            };

            await _repository.AddAsync(unidadMovil);
            return _mapper.Map<UnidadMovilDto>(unidadMovil);
        }
    }
} 