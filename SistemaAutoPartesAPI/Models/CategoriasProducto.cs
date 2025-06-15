using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models;

public partial class CategoriasProducto
{
    public int CategoriaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? CategoriaPadreId { get; set; }

    public virtual ICollection<AtributosProducto> AtributosProductos { get; set; } = new List<AtributosProducto>();

    public virtual CategoriasProducto? CategoriaPadre { get; set; }

    public virtual ICollection<CategoriasProducto> InverseCategoriaPadre { get; set; } = new List<CategoriasProducto>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
