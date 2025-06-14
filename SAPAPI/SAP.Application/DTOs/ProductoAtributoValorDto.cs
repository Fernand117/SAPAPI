namespace SAP.Application.DTOs
{
    public class ProductoAtributoValorDto
    {
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }
        public string? NombreAtributo { get; set; }
        public string? TipoDato { get; set; }
        public string? Valor { get; set; }
    }

    public class CreateProductoAtributoValorDto
    {
        public int AtributoId { get; set; }
        public string? Valor { get; set; }
    }

    public class UpdateProductoAtributoValorDto
    {
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }
        public string? Valor { get; set; }
    }
} 