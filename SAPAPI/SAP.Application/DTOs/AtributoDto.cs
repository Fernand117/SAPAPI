using System;

namespace SAP.Application.DTOs
{
    public class AtributoDto
    {
        public int AtributoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public bool Requerido { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class CreateAtributoDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public bool Requerido { get; set; }
    }

    public class UpdateAtributoDto
    {
        public int AtributoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public bool Requerido { get; set; }
    }
} 