using System;

namespace SAP.Application.DTOs
{
    public class CategoriaDto
    {
        public int CategoriaId { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activa { get; set; }
        public int? CategoriaPadreId { get; set; }
    }

    public class CreateCategoriaDto
    {
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public int? CategoriaPadreId { get; set; }
    }

    public class UpdateCategoriaDto
    {
        public int CategoriaId { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public int? CategoriaPadreId { get; set; }
    }
} 