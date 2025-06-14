using MediatR;
using Microsoft.EntityFrameworkCore;
using SAP.Application.Features.Shared;
using SAP.Application.Interfaces;
using System.Linq;

namespace SAP.Application.Features.Asistencias.Queries.SearchAsistencias;

public class SearchAsistenciasQuery : IRequest<Response<IEnumerable<AsistenciaDto>>>
{
    public int? EmpleadoId { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
}

public class SearchAsistenciasQueryHandler : IRequestHandler<SearchAsistenciasQuery, Response<IEnumerable<AsistenciaDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public SearchAsistenciasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<IEnumerable<AsistenciaDto>>> Handle(SearchAsistenciasQuery request, CancellationToken cancellationToken)
    {
        var asistencias = await _unitOfWork.Repository<Domain.Entities.Asistencia>().GetAllAsync();

        var query = asistencias.AsQueryable();

        if (request.EmpleadoId.HasValue)
        {
            query = query.Where(x => x.EmpleadoId == request.EmpleadoId.Value);
        }

        if (request.FechaInicio.HasValue)
        {
            query = query.Where(x => x.Fecha >= request.FechaInicio.Value);
        }

        if (request.FechaFin.HasValue)
        {
            query = query.Where(x => x.Fecha <= request.FechaFin.Value);
        }

        var result = await query.ToListAsync(cancellationToken);

        var dtos = result.Select(x => new AsistenciaDto
        {
            Id = x.Id,
            EmpleadoId = x.EmpleadoId,
            Fecha = x.Fecha,
            HoraEntrada = x.HoraEntrada,
            HoraSalida = x.HoraSalida,
            Estado = x.Estado
        });

        return new Response<IEnumerable<AsistenciaDto>>
        {
            Succeeded = true,
            Data = dtos
        };
    }
}

public class AsistenciaDto
{
    public int Id { get; set; }
    public int EmpleadoId { get; set; }
    public DateTime Fecha { get; set; }
    public TimeSpan HoraEntrada { get; set; }
    public TimeSpan? HoraSalida { get; set; }
    public string Estado { get; set; } = string.Empty;
} 