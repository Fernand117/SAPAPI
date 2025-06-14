using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Inventarios.Commands.DeleteInventario
{
    public class DeleteInventarioCommandHandler : IRequestHandler<DeleteInventarioCommand, bool>
    {
        private readonly IInventarioRepository _inventarioRepository;

        public DeleteInventarioCommandHandler(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }

        public async Task<bool> Handle(DeleteInventarioCommand request, CancellationToken cancellationToken)
        {
            var inventario = await _inventarioRepository.GetByIdAsync(request.Id);
            if (inventario == null)
                return false;

            await _inventarioRepository.DeleteAsync(inventario);
            return true;
        }
    }
} 