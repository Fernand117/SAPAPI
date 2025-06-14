using MediatR;
using SAP.Application.DTOs;
using System.Collections.Generic;

namespace SAP.Application.Features.Bitacoras.Queries.SearchBitacoras
{
    public class SearchBitacorasQuery : IRequest<IEnumerable<BitacoraDto>>
    {
        public int? UsuarioId { get; set; }
        public string Accion { get; set; }
        public string Tabla { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
} 