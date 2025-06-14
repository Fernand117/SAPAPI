using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.Bitacoras.Commands.UpdateBitacora
{
    public class UpdateBitacoraCommandHandler : IRequestHandler<UpdateBitacoraCommand, BitacoraDto>
    {
        private readonly IGenericRepository<Bitacora> _repository;

        public UpdateBitacoraCommandHandler(IGenericRepository<Bitacora> repository)
        {
            _repository = repository;
        }

        public async Task<BitacoraDto> Handle(UpdateBitacoraCommand request, CancellationToken cancellationToken)
        {
            var bitacora = await _repository.GetByIdAsync(request.BitacoraId);
            if (bitacora == null)
                return null;

            bitacora.Detalles = request.Detalles;

            await _repository.UpdateAsync(bitacora);

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