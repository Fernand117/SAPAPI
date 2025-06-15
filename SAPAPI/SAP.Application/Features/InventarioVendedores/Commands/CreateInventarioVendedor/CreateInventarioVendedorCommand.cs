using MediatR;
using SAP.Application.Features.Shared;
using SAP.Application.Interfaces;

namespace SAP.Application.Features.InventarioVendedores.Commands.CreateInventarioVendedor;

public class CreateInventarioVendedorCommand : IRequest<Response<int>>
{
    public int VendedorId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
}

public class CreateInventarioVendedorCommandHandler : IRequestHandler<CreateInventarioVendedorCommand, Response<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventarioVendedorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<int>> Handle(CreateInventarioVendedorCommand request, CancellationToken cancellationToken)
    {
        var inventarioVendedor = new Domain.Entities.InventarioVendedor
        {
            VendedorId = request.VendedorId,
            ProductoId = request.ProductoId,
            Cantidad = request.Cantidad
        };

        await _unitOfWork.Repository<Domain.Entities.InventarioVendedor>().AddAsync(inventarioVendedor);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new Response<int>
        {
            Succeeded = true,
            Data = inventarioVendedor.Id,
            Message = "InventarioVendedor creado exitosamente"
        };
    }
}