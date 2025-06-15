namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class ProductoDTO
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
    }
}