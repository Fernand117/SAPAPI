namespace SAP.Domain.Entities
{
    public class RolPermiso
    {
        public int RolId { get; set; }
        public int PermisoId { get; set; }

        // Relaciones
        public virtual Rol Rol { get; set; }
        public virtual Permiso Permiso { get; set; }
    }
} 