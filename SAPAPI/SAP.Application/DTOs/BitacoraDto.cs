using System;

namespace SAP.Application.DTOs
{
    public class BitacoraDto
    {
        public int BitacoraId { get; set; }
        public int UsuarioId { get; set; }
        public string Accion { get; set; }
        public string Tabla { get; set; }
        public string RegistroId { get; set; }
        public string Detalles { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreUsuario { get; set; }
    }

    public class CreateBitacoraDto
    {
        public int UsuarioId { get; set; }
        public string Accion { get; set; }
        public string Tabla { get; set; }
        public string RegistroId { get; set; }
        public string Detalles { get; set; }
    }

    public class UpdateBitacoraDto
    {
        public int BitacoraId { get; set; }
        public string Detalles { get; set; }
    }
} 