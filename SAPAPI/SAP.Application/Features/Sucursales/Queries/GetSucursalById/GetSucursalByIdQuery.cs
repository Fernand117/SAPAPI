using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Sucursales.Queries.GetSucursalById
{
    public class GetSucursalByIdQuery : IRequest<SucursalDto>
    {
        public int SucursalId { get; set; }
    }
} 