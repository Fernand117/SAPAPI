using System.Collections.Generic;

namespace SAP.Domain.Entities
{
    public class Rol
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // Relaciones
        public virtual ICollection<UsuarioRol> UsuarioRoles { get; set; }
        public virtual ICollection<RolPermiso> RolPermisos { get; set; }
    }
} 