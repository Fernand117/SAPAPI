using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;
using SAP.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.Incidencias.Commands.CreateIncidencia
{
    public class CreateIncidenciaCommandHandler : IRequestHandler<CreateIncidenciaCommand, IncidenciaDto>
    {
        private readonly IGenericRepository<Incidencia> _repository;
        private readonly IMapper _mapper;

        public CreateIncidenciaCommandHandler(IGenericRepository<Incidencia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IncidenciaDto> Handle(CreateIncidenciaCommand request, CancellationToken cancellationToken)
        {
            var incidencia = new Incidencia
            {
                EmpleadoId = request.EmpleadoId,
                Fecha = request.Fecha,
                Tipo = request.Tipo,
                Descripcion = request.Descripcion,
                Estado = request.Estado,
                Observaciones = request.Observaciones
            };

            await _repository.AddAsync(incidencia);
            return _mapper.Map<IncidenciaDto>(incidencia);
        }
    }
} 