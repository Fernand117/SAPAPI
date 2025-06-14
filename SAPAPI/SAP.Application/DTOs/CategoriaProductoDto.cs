using System;

namespace SAP.Application.DTOs
{
    public class CategoriaProductoDto
    {
        public int CategoriaProductoId { get; set; }
        public int CategoriaId { get; set; }
        public int ProductoId { get; set; }
    }

    public class CreateCategoriaProductoDto
    {
        public int CategoriaId { get; set; }
        public int ProductoId { get; set; }
    }

    public class UpdateCategoriaProductoDto
    {
        public int CategoriaProductoId { get; set; }
        public int CategoriaId { get; set; }
        public int ProductoId { get; set; }
    }
} 