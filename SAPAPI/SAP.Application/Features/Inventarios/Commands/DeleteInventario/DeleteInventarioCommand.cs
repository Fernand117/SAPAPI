using MediatR;

namespace SAP.Application.Features.Inventarios.Commands.DeleteInventario
{
    public class DeleteInventarioCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
} 