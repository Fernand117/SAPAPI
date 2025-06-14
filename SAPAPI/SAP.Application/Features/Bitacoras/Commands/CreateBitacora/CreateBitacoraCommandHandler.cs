using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.Bitacoras.Commands.CreateBitacora
{
    public class CreateBitacoraCommandHandler : IRequestHandler<CreateBitacoraCommand, BitacoraDto>
    {
        private readonly IGenericRepository<Bitacora> _repository;

        public CreateBitacoraCommandHandler(IGenericRepository<Bitacora> repository)
        {
            _repository = repository;
        }

        public async Task<BitacoraDto> Handle(CreateBitacoraCommand request, CancellationToken cancellationToken)
        {
            var bitacora = new Bitacora
            {
                UsuarioId = request.UsuarioId,
                Accion = request.Accion,
                Tabla = request.Tabla,
                RegistroId = request.RegistroId,
                Detalles = request.Detalles,
                Fecha = DateTime.UtcNow
            };

            await _repository.AddAsync(bitacora);

            return new BitacoraDto
            {
                BitacoraId = bitacora.BitacoraId,
                UsuarioId = bitacora.UsuarioId,
                Accion = bitacora.Accion,
                Tabla = bitacora.Tabla,
                RegistroId = bitacora.RegistroId,
                Detalles = bitacora.Detalles,
                Fecha = bitacora.Fecha
            };
        }
    }
} 