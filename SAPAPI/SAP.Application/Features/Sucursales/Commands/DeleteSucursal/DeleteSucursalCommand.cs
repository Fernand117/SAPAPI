using MediatR;

namespace SAP.Application.Features.Sucursales.Commands.DeleteSucursal
{
    public class DeleteSucursalCommand : IRequest<bool>
    {
        public int SucursalId { get; set; }
    }
} 