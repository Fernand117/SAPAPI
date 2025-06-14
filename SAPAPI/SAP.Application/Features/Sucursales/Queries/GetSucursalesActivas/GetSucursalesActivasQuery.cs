using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Sucursales.Queries.GetSucursalesActivas
{
    public class GetSucursalesActivasQuery : IRequest<IEnumerable<SucursalDto>>
    {
    }
} 