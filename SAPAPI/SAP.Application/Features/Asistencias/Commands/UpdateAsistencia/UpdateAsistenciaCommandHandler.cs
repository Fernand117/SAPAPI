using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;
using SAP.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.Asistencias.Commands.UpdateAsistencia
{
    public class UpdateAsistenciaCommandHandler : IRequestHandler<UpdateAsistenciaCommand, AsistenciaDto>
    {
        private readonly IGenericRepository<Asistencia> _repository;
        private readonly IMapper _mapper;

        public UpdateAsistenciaCommandHandler(IGenericRepository<Asistencia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AsistenciaDto> Handle(UpdateAsistenciaCommand request, CancellationToken cancellationToken)
        {
            var asistencia = await _repository.GetByIdAsync(request.AsistenciaId);
            if (asistencia == null)
                throw new Exception($"No se encontró la asistencia con ID {request.AsistenciaId}");

            asistencia.EmpleadoId = request.EmpleadoId;
            asistencia.Fecha = request.Fecha;
            asistencia.HoraEntrada = request.HoraEntrada;
            asistencia.HoraSalida = request.HoraSalida;
            asistencia.Estado = request.Estado;
            asistencia.Observaciones = request.Observaciones;

            await _repository.UpdateAsync(asistencia);
            return _mapper.Map<AsistenciaDto>(asistencia);
        }
    }
} 