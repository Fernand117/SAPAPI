using System;

namespace SAP.Application.DTOs
{
    public class ProductoAtributoDto
    {
        public int ProductoAtributoId { get; set; }
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }
        public string NombreProducto { get; set; }
        public string NombreAtributo { get; set; }
    }

    public class CreateProductoAtributoDto
    {
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }
    }

    public class UpdateProductoAtributoDto
    {
        public int ProductoAtributoId { get; set; }
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }
    }
} 