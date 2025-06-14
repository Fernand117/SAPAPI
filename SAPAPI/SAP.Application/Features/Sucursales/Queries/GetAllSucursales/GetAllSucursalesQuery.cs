using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Sucursales.Queries.GetAllSucursales
{
    public class GetAllSucursalesQuery : IRequest<IEnumerable<SucursalDto>>
    {
    }
} 