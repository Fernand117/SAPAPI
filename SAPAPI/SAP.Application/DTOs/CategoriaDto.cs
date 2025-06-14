using System;
using System.Collections.Generic;

namespace SAP.Application.DTOs
{
    public class CategoriaDto
    {
        public int CategoriaId { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Activa { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? CategoriaPadreId { get; set; }
        public string? NombreCategoriaPadre { get; set; }
        public int TotalProductos { get; set; }
        public ICollection<CategoriaDto> SubCategorias { get; set; } = new List<CategoriaDto>();
    }

    public class CreateCategoriaDto
    {
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? CategoriaPadreId { get; set; }
    }

    public class UpdateCategoriaDto
    {
        public int CategoriaId { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? CategoriaPadreId { get; set; }
    }

    public class CategoriaDetalleDto : CategoriaDto
    {
        public ICollection<ProductoDto> Productos { get; set; } = new List<ProductoDto>();
    }
} 