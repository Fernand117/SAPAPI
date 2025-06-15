using System;
using System.Collections.Generic;

namespace SistemaAutoPartesAPI.Models;

public partial class ProductoAtributoValor
{
    public int ProductoId { get; set; }

    public int AtributoId { get; set; }

    public string? Valor { get; set; }

    public virtual AtributosProducto Atributo { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
