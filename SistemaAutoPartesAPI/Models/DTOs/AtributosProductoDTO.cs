namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class AtributosProductoDTO
    {
        public int AtributoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string TipoDato { get; set; } = null!;
        public int CategoriaId { get; set; }
    }
}