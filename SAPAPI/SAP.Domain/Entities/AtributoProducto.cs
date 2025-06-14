using System.Collections.Generic;

namespace SAP.Domain.Entities
{
    public class AtributoProducto
    {
        public int AtributoId { get; set; }
        public string Nombre { get; set; }
        public string TipoDato { get; set; }
        public int CategoriaId { get; set; }

        // Relaciones
        public virtual CategoriaProducto Categoria { get; set; }
        public virtual ICollection<ProductoAtributoValor> ProductoAtributoValores { get; set; }
    }
} 