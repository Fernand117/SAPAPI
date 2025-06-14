using System;
using System.Collections.Generic;

namespace SAP.Domain.Entities
{
    public class Atributo
    {
        public int AtributoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public bool Requerido { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relaciones
        public virtual ICollection<ProductoAtributo> ProductoAtributos { get; set; }
    }
} 