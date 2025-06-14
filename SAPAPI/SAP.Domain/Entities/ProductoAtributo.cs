namespace SAP.Domain.Entities
{
    public class ProductoAtributo
    {
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }

        // Relaciones
        public Producto Producto { get; set; }
        public Atributo Atributo { get; set; }
    }
} 