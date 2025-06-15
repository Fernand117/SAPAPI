using System;

namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class VentaDTO
    {
        public int VentaId { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public int SucursalId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string? FormaPago { get; set; }
        public string? Notas { get; set; }
        public string? FirmaUrl { get; set; }
        public string? UbicacionGeo { get; set; }
    }
}