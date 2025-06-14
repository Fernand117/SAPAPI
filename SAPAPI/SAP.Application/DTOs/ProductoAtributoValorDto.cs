using System;

namespace SAP.Application.DTOs
{
    public class ProductoAtributoValorDto
    {
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }
        public string Valor { get; set; }
        public string NombreProducto { get; set; }
        public string NombreAtributo { get; set; }
    }

    public class CreateProductoAtributoValorDto
    {
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }
        public string Valor { get; set; }
    }

    public class UpdateProductoAtributoValorDto
    {
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }
        public string Valor { get; set; }
    }

    public class ProductoAtributoValorDetalleDto : ProductoAtributoValorDto
    {
        public ProductoDto Producto { get; set; }
        public AtributoDto Atributo { get; set; }
    }
} 