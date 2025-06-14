using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;
using SAP.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.Incidencias.Commands.UpdateIncidencia
{
    public class UpdateIncidenciaCommandHandler : IRequestHandler<UpdateIncidenciaCommand, IncidenciaDto>
    {
        private readonly IGenericRepository<Incidencia> _repository;
        private readonly IMapper _mapper;

        public UpdateIncidenciaCommandHandler(IGenericRepository<Incidencia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IncidenciaDto> Handle(UpdateIncidenciaCommand request, CancellationToken cancellationToken)
        {
            var incidencia = await _repository.GetByIdAsync(request.IncidenciaId);
            if (incidencia == null)
                throw new Exception($"No se encontró la incidencia con ID {request.IncidenciaId}");

            incidencia.EmpleadoId = request.EmpleadoId;
            incidencia.Fecha = request.Fecha;
            incidencia.Tipo = request.Tipo;
            incidencia.Descripcion = request.Descripcion;
            incidencia.Estado = request.Estado;
            incidencia.Observaciones = request.Observaciones;

            await _repository.UpdateAsync(incidencia);
            return _mapper.Map<IncidenciaDto>(incidencia);
        }
    }
} 