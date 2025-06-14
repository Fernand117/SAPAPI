using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Sucursales.Commands.UpdateSucursal
{
    public class UpdateSucursalCommand : IRequest<SucursalDto>
    {
        public UpdateSucursalDto? Sucursal { get; set; }
    }
}