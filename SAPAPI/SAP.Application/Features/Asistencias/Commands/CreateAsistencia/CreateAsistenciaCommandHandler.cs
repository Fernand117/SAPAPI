using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Application.Interfaces;
using SAP.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.Asistencias.Commands.CreateAsistencia
{
    public class CreateAsistenciaCommandHandler : IRequestHandler<CreateAsistenciaCommand, AsistenciaDto>
    {
        private readonly IGenericRepository<Asistencia> _repository;
        private readonly IMapper _mapper;

        public CreateAsistenciaCommandHandler(IGenericRepository<Asistencia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AsistenciaDto> Handle(CreateAsistenciaCommand request, CancellationToken cancellationToken)
        {
            var asistencia = new Asistencia
            {
                EmpleadoId = request.EmpleadoId,
                Fecha = request.Fecha,
                HoraEntrada = request.HoraEntrada,
                HoraSalida = request.HoraSalida,
                Estado = request.Estado,
                Observaciones = request.Observaciones
            };

            await _repository.AddAsync(asistencia);
            return _mapper.Map<AsistenciaDto>(asistencia);
        }
    }
} 