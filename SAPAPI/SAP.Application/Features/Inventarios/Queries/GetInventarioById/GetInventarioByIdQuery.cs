using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Inventarios.Queries.GetInventarioById
{
    public class GetInventarioByIdQuery : IRequest<InventarioDto>
    {
        public int Id { get; set; }
    }
} 