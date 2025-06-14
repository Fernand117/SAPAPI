using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Inventarios.Commands.UpdateInventario
{
    public class UpdateInventarioCommand : IRequest<bool>
    {
        public UpdateInventarioDto Inventario { get; set; }
    }
} 