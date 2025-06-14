using MediatR;
using SAP.Application.Features.Shared;
using SAP.Application.Interfaces;

namespace SAP.Application.Features.AtributoProductos.Commands.UpdateAtributoProducto;

public class UpdateAtributoProductoCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public int AtributoId { get; set; }
    public int ProductoId { get; set; }
    public string Valor { get; set; } = string.Empty;
}

public class UpdateAtributoProductoCommandHandler : IRequestHandler<UpdateAtributoProductoCommand, Response<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAtributoProductoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<int>> Handle(UpdateAtributoProductoCommand request, CancellationToken cancellationToken)
    {
        var atributoProducto = await _unitOfWork.Repository<Domain.Entities.AtributoProducto>().GetByIdAsync(request.Id);
        
        if (atributoProducto == null)
        {
            return new Response<int>
            {
                Succeeded = false,
                Message = "AtributoProducto no encontrado"
            };
        }

        atributoProducto.AtributoId = request.AtributoId;
        atributoProducto.ProductoId = request.ProductoId;
        atributoProducto.Valor = request.Valor;

        await _unitOfWork.Repository<Domain.Entities.AtributoProducto>().UpdateAsync(atributoProducto);
        await _unitOfWork.Commit(cancellationToken);

        return new Response<int>
        {
            Succeeded = true,
            Data = atributoProducto.Id,
            Message = "AtributoProducto actualizado exitosamente"
        };
    }
} 