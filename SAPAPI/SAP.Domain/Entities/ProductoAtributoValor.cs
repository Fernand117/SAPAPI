namespace SAP.Domain.Entities
{
    public class ProductoAtributoValor
    {
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }
        public string Valor { get; set; }

        // Relaciones
        public virtual Producto Producto { get; set; }
        public virtual AtributoProducto Atributo { get; set; }
    }
} 