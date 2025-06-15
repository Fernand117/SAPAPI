using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Marca { get; set; }

    public int CategoriaId { get; set; }

    public decimal Precio { get; set; }

    public string? ImagenUrl { get; set; }

    public bool Activo { get; set; }

    public virtual CategoriasProducto Categoria { get; set; } = null!;

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual ICollection<InventarioVendedor> InventarioVendedors { get; set; } = new List<InventarioVendedor>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();

    public virtual ICollection<ProductoAtributoValor> ProductoAtributoValors { get; set; } = new List<ProductoAtributoValor>();
}
