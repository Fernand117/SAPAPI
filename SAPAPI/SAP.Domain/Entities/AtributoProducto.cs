using System.Collections.Generic;

namespace SAP.Domain.Entities
{
    public class AtributoProducto
    {
        public int Id { get; set; }
        public int AtributoId { get; set; }
        public int ProductoId { get; set; }
        public string Valor { get; set; } = string.Empty;
        
        public virtual Atributo Atributo { get; set; } = null!;
        public virtual Producto Producto { get; set; } = null!;
    }
} 