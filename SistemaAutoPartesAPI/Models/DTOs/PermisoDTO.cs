namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class PermisoDTO
    {
        public int PermisoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Modulo { get; set; }
        public string? Descripcion { get; set; }
    }
}