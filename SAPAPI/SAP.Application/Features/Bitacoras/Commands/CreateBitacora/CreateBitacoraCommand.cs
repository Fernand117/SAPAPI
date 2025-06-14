using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Bitacoras.Commands.CreateBitacora
{
    public class CreateBitacoraCommand : IRequest<BitacoraDto>
    {
        public int UsuarioId { get; set; }
        public string Accion { get; set; }
        public string Tabla { get; set; }
        public string RegistroId { get; set; }
        public string Detalles { get; set; }
    }
} 