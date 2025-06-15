using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models;

public partial class AtributosProducto
{
    public int AtributoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string TipoDato { get; set; } = null!;

    public int CategoriaId { get; set; }

    public virtual CategoriasProducto Categoria { get; set; } = null!;

    public virtual ICollection<ProductoAtributoValor> ProductoAtributoValors { get; set; } = new List<ProductoAtributoValor>();
}
