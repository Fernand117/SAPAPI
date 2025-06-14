using MediatR;
using SAP.Application.Features.Shared;
using SAP.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SAP.Application.Features.AtributoProductos.Queries.SearchAtributoProductos;

public class SearchAtributoProductosQuery : IRequest<Response<IEnumerable<AtributoProductoDto>>>
{
    public int? AtributoId { get; set; }
    public int? ProductoId { get; set; }
}

public class SearchAtributoProductosQueryHandler : IRequestHandler<SearchAtributoProductosQuery, Response<IEnumerable<AtributoProductoDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public SearchAtributoProductosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<IEnumerable<AtributoProductoDto>>> Handle(SearchAtributoProductosQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Repository<Domain.Entities.AtributoProducto>().GetAllAsync();

        if (request.AtributoId.HasValue)
        {
            query = query.Where(x => x.AtributoId == request.AtributoId.Value);
        }

        if (request.ProductoId.HasValue)
        {
            query = query.Where(x => x.ProductoId == request.ProductoId.Value);
        }

        var atributoProductos = await query.ToListAsync(cancellationToken);

        var dtos = atributoProductos.Select(x => new AtributoProductoDto
        {
            Id = x.Id,
            AtributoId = x.AtributoId,
            ProductoId = x.ProductoId,
            Valor = x.Valor
        });

        return new Response<IEnumerable<AtributoProductoDto>>
        {
            Succeeded = true,
            Data = dtos
        };
    }
}

public class AtributoProductoDto
{
    public int Id { get; set; }
    public int AtributoId { get; set; }
    public int ProductoId { get; set; }
    public string Valor { get; set; } = string.Empty;
}