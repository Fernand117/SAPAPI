using System.Collections.Generic;

namespace SAP.Domain.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public bool Activo { get; set; }
        public int CategoriaId { get; set; }

        // Relaciones
        public Categoria Categoria { get; set; }
        public ICollection<ProductoAtributo> ProductoAtributos { get; set; }
        public ICollection<Inventario> Inventarios { get; set; }
        public ICollection<InventarioVendedor> InventarioVendedores { get; set; }
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
} 