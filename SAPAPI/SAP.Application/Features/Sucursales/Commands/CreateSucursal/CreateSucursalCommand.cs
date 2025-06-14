using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Sucursales.Commands.CreateSucursal
{
    public class CreateSucursalCommand : IRequest<SucursalDto>
    {
        public required CreateSucursalDto Sucursal { get; set; }
    }
} 