using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Sucursales.Queries.GetSucursalesByNombre
{
    public class GetSucursalesByNombreQuery : IRequest<IEnumerable<SucursalDto>>
    {
        public string Nombre { get; set; }
    }
} 