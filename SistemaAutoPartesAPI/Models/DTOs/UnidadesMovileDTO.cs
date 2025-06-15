using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class UnidadesMovileDTO
    {
        public int UnidadId { get; set; }
        public int SucursalId { get; set; }
        public string? Tipo { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Placa { get; set; }
        public bool Activa { get; set; }
    }
}