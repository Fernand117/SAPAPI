using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.InventarioVendedores.Queries.GetInventarioByEmpleado
{
    public class GetInventarioByEmpleadoQuery : IRequest<IEnumerable<InventarioVendedorDto>>
    {
        public int EmpleadoId { get; set; }
    }
} 