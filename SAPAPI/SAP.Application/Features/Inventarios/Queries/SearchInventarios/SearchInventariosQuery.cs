using MediatR;
using Microsoft.EntityFrameworkCore;
using SAP.Application.Features.Shared;
using SAP.Application.Interfaces;
using System.Linq;

namespace SAP.Application.Features.Inventarios.Queries.SearchInventarios;

public class SearchInventariosQuery : IRequest<Response<IEnumerable<InventarioDto>>>
{
    public int? ProductoId { get; set; }
    public int? SucursalId { get; set; }
}

public class SearchInventariosQueryHandler : IRequestHandler<SearchInventariosQuery, Response<IEnumerable<InventarioDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public SearchInventariosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<IEnumerable<InventarioDto>>> Handle(SearchInventariosQuery request, CancellationToken cancellationToken)
    {
        var inventarios = await _unitOfWork.Repository<Domain.Entities.Inventario>().GetAllAsync();

        var query = inventarios.AsQueryable();

        if (request.ProductoId.HasValue)
        {
            query = query.Where(x => x.ProductoId == request.ProductoId.Value);
        }

        if (request.SucursalId.HasValue)
        {
            query = query.Where(x => x.SucursalId == request.SucursalId.Value);
        }

        var result = await query.ToListAsync(cancellationToken);

        var dtos = result.Select(x => new InventarioDto
        {
            Id = x.Id,
            ProductoId = x.ProductoId,
            SucursalId = x.SucursalId,
            Cantidad = x.Cantidad,
            StockMinimo = x.StockMinimo,
            StockMaximo = x.StockMaximo
        });

        return new Response<IEnumerable<InventarioDto>>
        {
            Succeeded = true,
            Data = dtos
        };
    }
}

public class InventarioDto
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public int SucursalId { get; set; }
    public int Cantidad { get; set; }
    public int StockMinimo { get; set; }
    public int StockMaximo { get; set; }
} 