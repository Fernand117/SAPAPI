using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.UnidadMoviles.Commands.CreateUnidadMovil
{
    public class CreateUnidadMovilCommand : IRequest<UnidadMovilDto>
    {
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