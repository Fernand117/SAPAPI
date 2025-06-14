using System;

namespace SAP.Domain.Entities
{
    public class UsuarioUnidad
    {
        public int UsuarioId { get; set; }
        public int UnidadId { get; set; }
        public int SucursalId { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime? FechaDesasignacion { get; set; }
        public bool Activa { get; set; }

        // Relaciones
        public virtual Usuario Usuario { get; set; }
        public virtual UnidadMovil UnidadMovil { get; set; }
        public virtual Sucursal Sucursal { get; set; }
    }
} 