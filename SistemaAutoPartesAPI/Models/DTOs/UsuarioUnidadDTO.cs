using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class UsuarioUnidadDTO
    {
        public int UsuarioId { get; set; }
        public int UnidadId { get; set; }
        public int SucursalId { get; set; }
        public DateOnly FechaAsignacion { get; set; }
    }
}