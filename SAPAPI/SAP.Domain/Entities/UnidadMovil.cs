using System;
using System.Collections.Generic;

namespace SAP.Domain.Entities
{
    public class UnidadMovil
    {
        public int UnidadMovilId { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        public string Estado { get; set; }
        public int UnidadId { get; set; }
        public int SucursalId { get; set; }
        public string Tipo { get; set; }
        public bool Activa { get; set; }
        public DateTime FechaRegistro { get; set; }

        // Relaciones
        public virtual Sucursal Sucursal { get; set; }
        public virtual ICollection<UsuarioUnidad> UsuarioUnidades { get; set; }
    }
} 