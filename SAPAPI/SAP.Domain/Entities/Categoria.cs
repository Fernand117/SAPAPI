using System;
using System.Collections.Generic;

namespace SAP.Domain.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activa { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relaciones
        public ICollection<Producto> Productos { get; set; }
    }
} 