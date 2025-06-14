using System.Collections.Generic;

namespace SAP.Application.DTOs
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }
        public required string Codigo { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public bool Activo { get; set; }
        public int CategoriaId { get; set; }
        public string? CategoriaNombre { get; set; }
        public ICollection<ProductoAtributoDto>? Atributos { get; set; }
    }

    public class CreateProductoDto
    {
        public required string Codigo { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public int CategoriaId { get; set; }
        public ICollection<CreateProductoAtributoDto>? Atributos { get; set; }
    }

    public class UpdateProductoDto
    {
        public int ProductoId { get; set; }
        public required string Codigo { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public bool Activo { get; set; }
        public int CategoriaId { get; set; }
        public ICollection<UpdateProductoAtributoDto>? Atributos { get; set; }
    }

    public class ProductoAtributoDto
    {
        public int AtributoId { get; set; }
        public required string Nombre { get; set; }
        public required string Valor { get; set; }
    }

    public class CreateProductoAtributoDto
    {
        public int AtributoId { get; set; }
        public required string Valor { get; set; }
    }

    public class UpdateProductoAtributoDto
    {
        public int AtributoId { get; set; }
        public required string Valor { get; set; }
    }
} 