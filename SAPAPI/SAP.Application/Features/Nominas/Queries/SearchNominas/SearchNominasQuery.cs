using MediatR;
using Microsoft.EntityFrameworkCore;
using SAP.Application.Features.Shared;
using SAP.Application.Interfaces;
using System.Linq;

namespace SAP.Application.Features.Nominas.Queries.SearchNominas;

public class SearchNominasQuery : IRequest<Response<IEnumerable<NominaDto>>>
{
    public int? EmpleadoId { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
}

public class SearchNominasQueryHandler : IRequestHandler<SearchNominasQuery, Response<IEnumerable<NominaDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public SearchNominasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<IEnumerable<NominaDto>>> Handle(SearchNominasQuery request, CancellationToken cancellationToken)
    {
        var nominas = await _unitOfWork.Repository<Domain.Entities.Nomina>().GetAllAsync();

        var query = nominas.AsQueryable();

        if (request.EmpleadoId.HasValue)
        {
            query = query.Where(x => x.EmpleadoId == request.EmpleadoId.Value);
        }

        if (request.FechaInicio.HasValue)
        {
            query = query.Where(x => x.FechaInicio >= request.FechaInicio.Value);
        }

        if (request.FechaFin.HasValue)
        {
            query = query.Where(x => x.FechaFin <= request.FechaFin.Value);
        }

        var result = await query.ToListAsync(cancellationToken);

        var dtos = result.Select(x => new NominaDto
        {
            Id = x.Id,
            EmpleadoId = x.EmpleadoId,
            FechaInicio = x.FechaInicio,
            FechaFin = x.FechaFin,
            SalarioBase = x.SalarioBase,
            Bonificaciones = x.Bonificaciones,
            Deducciones = x.Deducciones,
            Total = x.Total
        });

        return new Response<IEnumerable<NominaDto>>
        {
            Succeeded = true,
            Data = dtos
        };
    }
}

public class NominaDto
{
    public int Id { get; set; }
    public int EmpleadoId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public decimal SalarioBase { get; set; }
    public decimal Bonificaciones { get; set; }
    public decimal Deducciones { get; set; }
    public decimal Total { get; set; }
} 