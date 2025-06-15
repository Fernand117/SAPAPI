using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class RoleDTO
    {
        public int RolId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
    }
}