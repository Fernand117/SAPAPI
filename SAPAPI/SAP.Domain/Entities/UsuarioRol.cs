namespace SAP.Domain.Entities
{
    public class UsuarioRol
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }

        // Relaciones
        public virtual Usuario Usuario { get; set; }
        public virtual Rol Rol { get; set; }
    }
} 