using MediatR;
using SAP.Application.Features.Shared;
using SAP.Application.Interfaces;

namespace SAP.Application.Features.PermisoSalidas.Commands.CreatePermisoSalida;

public class CreatePermisoSalidaCommand : IRequest<Response<int>>
{
    public int EmpleadoId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
}

public class CreatePermisoSalidaCommandHandler : IRequestHandler<CreatePermisoSalidaCommand, Response<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePermisoSalidaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<int>> Handle(CreatePermisoSalidaCommand request, CancellationToken cancellationToken)
    {
        var permisoSalida = new Domain.Entities.PermisoSalida
        {
            EmpleadoId = request.EmpleadoId,
            FechaInicio = request.FechaInicio,
            FechaFin = request.FechaFin,
            Motivo = request.Motivo,
            Estado = request.Estado
        };

        await _unitOfWork.Repository<Domain.Entities.PermisoSalida>().AddAsync(permisoSalida);
        await _unitOfWork.Commit(cancellationToken);

        return new Response<int>
        {
            Succeeded = true,
            Data = permisoSalida.Id,
            Message = "PermisoSalida creado exitosamente"
        };
    }
} 