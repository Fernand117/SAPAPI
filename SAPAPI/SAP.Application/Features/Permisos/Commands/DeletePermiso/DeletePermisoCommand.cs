using MediatR;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Permisos.Commands.DeletePermiso
{
    public class DeletePermisoCommand : IRequest<bool>
    {
        public int PermisoId { get; set; }
    }

    public class DeletePermisoCommandHandler : IRequestHandler<DeletePermisoCommand, bool>
    {
        private readonly IGenericRepository<Permiso> _permisoRepository;

        public DeletePermisoCommandHandler(IGenericRepository<Permiso> permisoRepository)
        {
            _permisoRepository = permisoRepository;
        }

        public async Task<bool> Handle(DeletePermisoCommand request, CancellationToken cancellationToken)
        {
            var permiso = await _permisoRepository.GetByIdAsync(request.PermisoId);
            if (permiso == null)
                throw new Exception($"No se encontró el permiso con ID {request.PermisoId}");

            return await _permisoRepository.DeleteAsync(permiso);
        }
    }
} 