using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Inventarios.Queries.GetInventarioBySucursal
{
    public class GetInventarioBySucursalQuery : IRequest<IEnumerable<InventarioDto>>
    {
        public int SucursalId { get; set; }
    }
} 