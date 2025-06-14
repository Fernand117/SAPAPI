using System;
using System.Collections.Generic;

namespace SAP.Application.DTOs
{
    public class VentaDto
    {
        public int VentaId { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public int SucursalId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string? FormaPago { get; set; }
        public string? Notas { get; set; }
        public string? FirmaUrl { get; set; }
        public string? UbicacionGeo { get; set; }
        public string? Estado { get; set; }
        public string? ClienteNombre { get; set; }
        public string? EmpleadoNombre { get; set; }
        public string? SucursalNombre { get; set; }
        public ICollection<DetalleVentaDto>? Detalles { get; set; }
    }

    public class CreateVentaDto
    {
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public int SucursalId { get; set; }
        public decimal Total { get; set; }
        public string? FormaPago { get; set; }
        public string? Notas { get; set; }
        public string? FirmaUrl { get; set; }
        public string? UbicacionGeo { get; set; }
        public ICollection<CreateDetalleVentaDto>? Detalles { get; set; }
    }

    public class UpdateVentaDto
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public int SucursalId { get; set; }
        public decimal Total { get; set; }
        public string? FormaPago { get; set; }
        public string? Notas { get; set; }
        public string? FirmaUrl { get; set; }
        public string? UbicacionGeo { get; set; }
        public string? Estado { get; set; }
        public ICollection<UpdateDetalleVentaDto>? Detalles { get; set; }
    }
} 