using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Inventarios.Commands.CreateInventario
{
    public class CreateInventarioCommand : IRequest<int>
    {
        public CreateInventarioDto Inventario { get; set; }
    }
} 