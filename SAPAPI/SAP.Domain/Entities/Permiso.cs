using System.Collections.Generic;

namespace SAP.Domain.Entities
{
    public class Permiso
    {
        public int PermisoId { get; set; }
        public string Nombre { get; set; }
        public string Modulo { get; set; }
        public string Descripcion { get; set; }

        // Relaciones
        public virtual ICollection<RolPermiso> RolPermisos { get; set; }
    }
} 