using System;
using System.Collections.Generic;

namespace SAP.Application.DTOs
{
    public class VentaDto
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public int SucursalId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public string ClienteNombre { get; set; }
        public string EmpleadoNombre { get; set; }
        public string SucursalNombre { get; set; }
        public ICollection<DetalleVentaDto> Detalles { get; set; }
    }

    public class CreateVentaDto
    {
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public int SucursalId { get; set; }
        public ICollection<CreateDetalleVentaDto> Detalles { get; set; }
    }

    public class UpdateVentaDto
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public int SucursalId { get; set; }
        public string Estado { get; set; }
        public ICollection<UpdateDetalleVentaDto> Detalles { get; set; }
    }

    public class DetalleVentaDto
    {
        public int DetalleVentaId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public string ProductoNombre { get; set; }
    }

    public class CreateDetalleVentaDto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

    public class UpdateDetalleVentaDto
    {
        public int DetalleVentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
} 