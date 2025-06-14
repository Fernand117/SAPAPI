using MediatR;
using Microsoft.EntityFrameworkCore;
using SAP.Application.Features.Shared;
using SAP.Application.Interfaces;
using System.Linq;

namespace SAP.Application.Features.InventarioVendedores.Queries.SearchInventarioVendedores;

public class SearchInventarioVendedoresQuery : IRequest<Response<IEnumerable<InventarioVendedorDto>>>
{
    public int? VendedorId { get; set; }
    public int? ProductoId { get; set; }
}

public class SearchInventarioVendedoresQueryHandler : IRequestHandler<SearchInventarioVendedoresQuery, Response<IEnumerable<InventarioVendedorDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public SearchInventarioVendedoresQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<IEnumerable<InventarioVendedorDto>>> Handle(SearchInventarioVendedoresQuery request, CancellationToken cancellationToken)
    {
        var inventarioVendedores = await _unitOfWork.Repository<Domain.Entities.InventarioVendedor>().GetAllAsync();

        var query = inventarioVendedores.AsQueryable();

        if (request.VendedorId.HasValue)
        {
            query = query.Where(x => x.VendedorId == request.VendedorId.Value);
        }

        if (request.ProductoId.HasValue)
        {
            query = query.Where(x => x.ProductoId == request.ProductoId.Value);
        }

        var result = await query.ToListAsync(cancellationToken);

        var dtos = result.Select(x => new InventarioVendedorDto
        {
            Id = x.Id,
            VendedorId = x.VendedorId,
            ProductoId = x.ProductoId,
            Cantidad = x.Cantidad
        });

        return new Response<IEnumerable<InventarioVendedorDto>>
        {
            Succeeded = true,
            Data = dtos
        };
    }
}

public class InventarioVendedorDto
{
    public int Id { get; set; }
    public int VendedorId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
} 