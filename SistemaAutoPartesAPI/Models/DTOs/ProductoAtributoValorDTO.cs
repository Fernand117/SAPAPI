using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class ProductoAtributoValorDTO
    {
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }
        public string? Valor { get; set; }
    }
}