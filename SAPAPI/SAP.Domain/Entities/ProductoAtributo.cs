using System;

namespace SAP.Domain.Entities
{
    public class ProductoAtributo
    {
        public int ProductoAtributoId { get; set; }
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }
        public string Valor { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relaciones
        public virtual Producto Producto { get; set; }
        public virtual Atributo Atributo { get; set; }
    }
} 