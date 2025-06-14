using System;

namespace SAP.Application.DTOs
{
    public class UnidadMovilDto
    {
        public int UnidadMovilId { get; set; }
        public string Placa { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public int Anio { get; set; }
        public string Color { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public int SucursalId { get; set; }
    }

    public class CreateUnidadMovilDto
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        public string Estado { get; set; }
    }

    public class UpdateUnidadMovilDto
    {
        public int UnidadMovilId { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        public string Estado { get; set; }
    }
} 