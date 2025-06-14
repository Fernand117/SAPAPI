using MediatR;
using SAP.Application.Features.Shared;
using SAP.Application.Interfaces;

namespace SAP.Application.Features.DetalleVentas.Commands.CreateDetalleVenta;

public class CreateDetalleVentaCommand : IRequest<Response<int>>
{
    public int VentaId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
}

public class CreateDetalleVentaCommandHandler : IRequestHandler<CreateDetalleVentaCommand, Response<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDetalleVentaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<int>> Handle(CreateDetalleVentaCommand request, CancellationToken cancellationToken)
    {
        var detalleVenta = new Domain.Entities.DetalleVenta
        {
            VentaId = request.VentaId,
            ProductoId = request.ProductoId,
            Cantidad = request.Cantidad,
            PrecioUnitario = request.PrecioUnitario,
            Subtotal = request.Subtotal
        };

        await _unitOfWork.Repository<Domain.Entities.DetalleVenta>().AddAsync(detalleVenta);
        await _unitOfWork.Commit(cancellationToken);

        return new Response<int>
        {
            Succeeded = true,
            Data = detalleVenta.Id,
            Message = "DetalleVenta creado exitosamente"
        };
    }
} 