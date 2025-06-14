using System;

namespace SAP.Application.DTOs
{
    public class CategoriaDto
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activa { get; set; }
    }

    public class CreateCategoriaDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class UpdateCategoriaDto
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activa { get; set; }
    }
} 