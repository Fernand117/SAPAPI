using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Ventas.Commands.CreateVenta
{
    public class CreateVentaCommand : IRequest<VentaDto>
    {
        public CreateVentaDto Venta { get; set; }
    }
} 