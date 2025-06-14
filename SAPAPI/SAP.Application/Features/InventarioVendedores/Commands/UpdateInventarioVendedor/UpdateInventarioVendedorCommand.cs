using MediatR;
using SAP.Application.Features.Shared;
using SAP.Application.Interfaces;

namespace SAP.Application.Features.InventarioVendedores.Commands.UpdateInventarioVendedor;

public class UpdateInventarioVendedorCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public int VendedorId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
}

public class UpdateInventarioVendedorCommandHandler : IRequestHandler<UpdateInventarioVendedorCommand, Response<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventarioVendedorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<int>> Handle(UpdateInventarioVendedorCommand request, CancellationToken cancellationToken)
    {
        var inventarioVendedor = await _unitOfWork.Repository<Domain.Entities.InventarioVendedor>().GetByIdAsync(request.Id);
        
        if (inventarioVendedor == null)
        {
            return new Response<int>
            {
                Succeeded = false,
                Message = "InventarioVendedor no encontrado"
            };
        }

        inventarioVendedor.VendedorId = request.VendedorId;
        inventarioVendedor.ProductoId = request.ProductoId;
        inventarioVendedor.Cantidad = request.Cantidad;

        await _unitOfWork.Repository<Domain.Entities.InventarioVendedor>().UpdateAsync(inventarioVendedor);
        await _unitOfWork.Commit(cancellationToken);

        return new Response<int>
        {
            Succeeded = true,
            Data = inventarioVendedor.Id,
            Message = "InventarioVendedor actualizado exitosamente"
        };
    }
} 