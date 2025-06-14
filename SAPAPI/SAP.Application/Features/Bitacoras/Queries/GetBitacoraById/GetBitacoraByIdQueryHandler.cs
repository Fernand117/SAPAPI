using MediatR;
using Microsoft.EntityFrameworkCore;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.Bitacoras.Queries.GetBitacoraById
{
    public class GetBitacoraByIdQueryHandler : IRequestHandler<GetBitacoraByIdQuery, BitacoraDto>
    {
        private readonly IGenericRepository<Domain.Entities.Bitacora> _repository;

        public GetBitacoraByIdQueryHandler(IGenericRepository<Domain.Entities.Bitacora> repository)
        {
            _repository = repository;
        }

        public async Task<BitacoraDto> Handle(GetBitacoraByIdQuery request, CancellationToken cancellationToken)
        {
            var bitacora = await _repository.GetByIdAsync(request.BitacoraId);
            if (bitacora == null)
                return null;

            return new BitacoraDto
            {
                BitacoraId = bitacora.BitacoraId,
                UsuarioId = bitacora.UsuarioId,
                Accion = bitacora.Accion,
                Tabla = bitacora.Tabla,
                RegistroId = bitacora.RegistroId,
                Detalles = bitacora.Detalles,
                Fecha = bitacora.Fecha,
                NombreUsuario = bitacora.Usuario?.Username
            };
        }
    }
} 