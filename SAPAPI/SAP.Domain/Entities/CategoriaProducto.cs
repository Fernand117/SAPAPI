using System.Collections.Generic;

namespace SAP.Domain.Entities
{
    public class CategoriaProducto
    {
        public int CategoriaProductoId { get; set; }
        public int CategoriaId { get; set; }
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? CategoriaPadreId { get; set; }

        // Relaciones
        public virtual CategoriaProducto CategoriaPadre { get; set; }
        public virtual ICollection<CategoriaProducto> SubCategorias { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<AtributoProducto> Atributos { get; set; }
    }
} 