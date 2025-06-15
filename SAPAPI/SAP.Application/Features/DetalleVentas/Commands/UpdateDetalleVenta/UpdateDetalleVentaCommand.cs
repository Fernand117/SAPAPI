using MediatR;
using SAP.Application.Features.Shared;
using SAP.Application.Interfaces;

namespace SAP.Application.Features.DetalleVentas.Commands.UpdateDetalleVenta;

public class UpdateDetalleVentaCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public int VentaId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
}

public class UpdateDetalleVentaCommandHandler : IRequestHandler<UpdateDetalleVentaCommand, Response<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDetalleVentaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<int>> Handle(UpdateDetalleVentaCommand request, CancellationToken cancellationToken)
    {
        var detalleVenta = await _unitOfWork.Repository<Domain.Entities.DetalleVenta>().GetByIdAsync(request.Id);
        
        if (detalleVenta == null)
        {
            return new Response<int>
            {
                Succeeded = false,
                Message = "DetalleVenta no encontrado"
            };
        }

        detalleVenta.VentaId = request.VentaId;
        detalleVenta.ProductoId = request.ProductoId;
        detalleVenta.Cantidad = request.Cantidad;
        detalleVenta.PrecioUnitario = request.PrecioUnitario;
        detalleVenta.Subtotal = request.Subtotal;

        await _unitOfWork.Repository<Domain.Entities.DetalleVenta>().UpdateAsync(detalleVenta);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new Response<int>
        {
            Succeeded = true,
            Data = detalleVenta.Id,
            Message = "DetalleVenta actualizado exitosamente"
        };
    }
}