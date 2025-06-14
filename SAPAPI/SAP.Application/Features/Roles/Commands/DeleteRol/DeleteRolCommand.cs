using MediatR;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Roles.Commands.DeleteRol
{
    public class DeleteRolCommand : IRequest<bool>
    {
        public int RolId { get; set; }
    }

    public class DeleteRolCommandHandler : IRequestHandler<DeleteRolCommand, bool>
    {
        private readonly IGenericRepository<Rol> _rolRepository;

        public DeleteRolCommandHandler(IGenericRepository<Rol> rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<bool> Handle(DeleteRolCommand request, CancellationToken cancellationToken)
        {
            var rol = await _rolRepository.GetByIdAsync(request.RolId);
            if (rol == null)
                throw new Exception($"No se encontró el rol con ID {request.RolId}");

            return await _rolRepository.DeleteAsync(rol);
        }
    }
} 