using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Sucursales.Commands.DeleteSucursal
{
    public class DeleteSucursalCommandHandler : IRequestHandler<DeleteSucursalCommand, bool>
    {
        private readonly ISucursalRepository _sucursalRepository;

        public DeleteSucursalCommandHandler(ISucursalRepository sucursalRepository)
        {
            _sucursalRepository = sucursalRepository;
        }

        public async Task<bool> Handle(DeleteSucursalCommand request, CancellationToken cancellationToken)
        {
            var sucursal = await _sucursalRepository.GetByIdAsync(request.SucursalId);
            if (sucursal == null)
                return false;

            return await _sucursalRepository.DeleteAsync(sucursal);
        }
    }
} 