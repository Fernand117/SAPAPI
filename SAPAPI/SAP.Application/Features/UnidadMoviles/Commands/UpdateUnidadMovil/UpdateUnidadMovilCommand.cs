using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.UnidadMoviles.Commands.UpdateUnidadMovil
{
    public class UpdateUnidadMovilCommand : IRequest<UnidadMovilDto>
    {
        public int UnidadMovilId { get; set; }
        public string Placa { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public int Anio { get; set; }
        public string Color { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public int SucursalId { get; set; }
    }
} 