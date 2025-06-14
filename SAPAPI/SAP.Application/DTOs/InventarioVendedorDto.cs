using System;

namespace SAP.Application.DTOs
{
    public class InventarioVendedorDto
    {
        public int UsuarioId { get; set; }
        public string? UsuarioNombre { get; set; }
        public int ProductoId { get; set; }
        public string? ProductoNombre { get; set; }
        public int SucursalId { get; set; }
        public string? SucursalNombre { get; set; }
        public int Cantidad { get; set; }
    }

    public class CreateInventarioVendedorDto
    {
        public int UsuarioId { get; set; }
        public int ProductoId { get; set; }
        public int SucursalId { get; set; }
        public int Cantidad { get; set; }
    }

    public class UpdateInventarioVendedorDto
    {
        public int UsuarioId { get; set; }
        public int ProductoId { get; set; }
        public int SucursalId { get; set; }
        public int Cantidad { get; set; }
    }

    public class InventarioVendedorDetalleDto : InventarioVendedorDto
    {
        public ProductoDto Producto { get; set; }
        public EmpleadoDto Empleado { get; set; }
    }
} 