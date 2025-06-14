using System;

namespace SAP.Domain.Entities
{
    public class Bitacora
    {
        public int BitacoraId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
        public string Tabla { get; set; }
        public string RegistroId { get; set; }
        public string Detalles { get; set; }

        // Relaciones
        public Usuario Usuario { get; set; }
    }
} 