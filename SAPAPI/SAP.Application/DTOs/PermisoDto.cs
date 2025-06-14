using System;

namespace SAP.Application.DTOs
{
    public class PermisoDto
    {
        public int PermisoId { get; set; }
        public string Nombre { get; set; }
        public string Modulo { get; set; }
        public string Descripcion { get; set; }
    }

    public class CreatePermisoDto
    {
        public string Nombre { get; set; }
        public string Modulo { get; set; }
        public string Descripcion { get; set; }
    }

    public class UpdatePermisoDto
    {
        public int PermisoId { get; set; }
        public string Nombre { get; set; }
        public string Modulo { get; set; }
        public string Descripcion { get; set; }
    }
} 