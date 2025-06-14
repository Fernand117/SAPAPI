using MediatR;
using Microsoft.EntityFrameworkCore;
using SAP.Application.Features.Shared;
using SAP.Application.Interfaces;
using System.Linq;

namespace SAP.Application.Features.DetalleVentas.Queries.SearchDetalleVentas;

public class SearchDetalleVentasQuery : IRequest<Response<IEnumerable<DetalleVentaDto>>>
{
    public int? VentaId { get; set; }
    public int? ProductoId { get; set; }
}

public class SearchDetalleVentasQueryHandler : IRequestHandler<SearchDetalleVentasQuery, Response<IEnumerable<DetalleVentaDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public SearchDetalleVentasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<IEnumerable<DetalleVentaDto>>> Handle(SearchDetalleVentasQuery request, CancellationToken cancellationToken)
    {
        var detallesVenta = _unitOfWork.Repository<Domain.Entities.DetalleVenta>().GetAllAsync();

        var query = detallesVenta.AsQueryable();

        if (request.VentaId.HasValue)
        {
            query = query.Where(x => x.VentaId == request.VentaId.Value);
        }

        if (request.ProductoId.HasValue)
        {
            query = query.Where(x => x.ProductoId == request.ProductoId.Value);
        }

        var result = await query.ToListAsync(cancellationToken);

        var dtos = result.Select(x => new DetalleVentaDto
        {
            Id = x.Id,
            VentaId = x.VentaId,
            ProductoId = x.ProductoId,
            Cantidad = x.Cantidad,
            PrecioUnitario = x.PrecioUnitario,
            Subtotal = x.Subtotal
        });

        return new Response<IEnumerable<DetalleVentaDto>>
        {
            Succeeded = true,
            Data = dtos
        };
    }
}

public class DetalleVentaDto
{
    public int Id { get; set; }
    public int VentaId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
} 