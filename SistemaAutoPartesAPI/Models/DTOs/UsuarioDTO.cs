namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class UsuarioDTO
    {
        public int UsuarioId { get; set; }
        public int EmpleadoId { get; set; }
        public string Username { get; set; } = null!;
        public bool Activo { get; set; }
    }
}