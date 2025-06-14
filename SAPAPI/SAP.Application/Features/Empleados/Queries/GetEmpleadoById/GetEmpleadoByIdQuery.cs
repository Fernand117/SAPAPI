using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Empleados.Queries.GetEmpleadoById
{
    public class GetEmpleadoByIdQuery : IRequest<EmpleadoDto>
    {
        public int EmpleadoId { get; set; }
    }
} 