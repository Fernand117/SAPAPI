using MediatR;
using SAP.Application.Features.Shared;
using SAP.Application.Interfaces;

namespace SAP.Application.Features.AtributoProductos.Commands.CreateAtributoProducto;

public class CreateAtributoProductoCommand : IRequest<Response<int>>
{
    public int AtributoId { get; set; }
    public int ProductoId { get; set; }
    public string Valor { get; set; } = string.Empty;
}

public class CreateAtributoProductoCommandHandler : IRequestHandler<CreateAtributoProductoCommand, Response<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAtributoProductoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<int>> Handle(CreateAtributoProductoCommand request, CancellationToken cancellationToken)
    {
        var atributoProducto = new Domain.Entities.AtributoProducto
        {
            AtributoId = request.AtributoId,
            ProductoId = request.ProductoId,
            Valor = request.Valor
        };

        await _unitOfWork.Repository<Domain.Entities.AtributoProducto>().AddAsync(atributoProducto);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new Response<int>
        {
            Succeeded = true,
            Data = atributoProducto.Id,
            Message = "AtributoProducto creado exitosamente"
        };
    }
}