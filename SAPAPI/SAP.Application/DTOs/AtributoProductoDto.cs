using System;

namespace SAP.Application.DTOs
{
    public class AtributoProductoDto
    {
        public int AtributoProductoId { get; set; }
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }
        public string Valor { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Propiedades de navegación
        public string NombreProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreAtributo { get; set; }
        public string TipoAtributo { get; set; }
    }

    public class CreateAtributoProductoDto
    {
        public int ProductoId { get; set; }
        public int AtributoId { get; set; }
        public string Valor { get; set; }
    }

    public class UpdateAtributoProductoDto
    {
        public int AtributoProductoId { get; set; }
        public string Valor { get; set; }
    }

    public class AtributoProductoDetalleDto : AtributoProductoDto
    {
        public ProductoDto Producto { get; set; }
        public AtributoDto Atributo { get; set; }
    }
} 