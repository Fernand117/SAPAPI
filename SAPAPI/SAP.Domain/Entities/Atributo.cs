using System.Collections.Generic;

namespace SAP.Domain.Entities
{
    public class Atributo
    {
        public int AtributoId { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }

        // Relaciones
        public ICollection<ProductoAtributo> ProductoAtributos { get; set; }
    }
} 