namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class CategoriasProductoDTO
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int? CategoriaPadreId { get; set; }
    }
}