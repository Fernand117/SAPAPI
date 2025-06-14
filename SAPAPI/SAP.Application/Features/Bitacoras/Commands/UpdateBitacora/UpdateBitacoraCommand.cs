using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Bitacoras.Commands.UpdateBitacora
{
    public class UpdateBitacoraCommand : IRequest<BitacoraDto>
    {
        public int BitacoraId { get; set; }
        public string Detalles { get; set; }
    }
} 