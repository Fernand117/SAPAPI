using MediatR;
using Microsoft.EntityFrameworkCore;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Application.Features.Bitacoras.Queries.SearchBitacoras
{
    public class SearchBitacorasQueryHandler : IRequestHandler<SearchBitacorasQuery, IEnumerable<BitacoraDto>>
    {
        private readonly IGenericRepository<Domain.Entities.Bitacora> _repository;

        public SearchBitacorasQueryHandler(IGenericRepository<Domain.Entities.Bitacora> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BitacoraDto>> Handle(SearchBitacorasQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Query()
                .Include(b => b.Usuario)
                .AsQueryable();

            if (request.UsuarioId.HasValue)
                query = query.Where(b => b.UsuarioId == request.UsuarioId.Value);

            if (!string.IsNullOrEmpty(request.Accion))
                query = query.Where(b => b.Accion.Contains(request.Accion));

            if (!string.IsNullOrEmpty(request.Tabla))
                query = query.Where(b => b.Tabla.Contains(request.Tabla));

            if (request.FechaInicio.HasValue)
                query = query.Where(b => b.Fecha >= request.FechaInicio.Value);

            if (request.FechaFin.HasValue)
                query = query.Where(b => b.Fecha <= request.FechaFin.Value);

            var bitacoras = await query.ToListAsync(cancellationToken);

            return bitacoras.Select(b => new BitacoraDto
            {
                BitacoraId = b.BitacoraId,
                UsuarioId = b.UsuarioId,
                Accion = b.Accion,
                Tabla = b.Tabla,
                RegistroId = b.RegistroId,
                Detalles = b.Detalles,
                Fecha = b.Fecha,
                NombreUsuario = b.Usuario?.Username
            });
        }
    }
} 