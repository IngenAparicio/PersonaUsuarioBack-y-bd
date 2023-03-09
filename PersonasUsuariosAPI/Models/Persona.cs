using System;
using System.Collections.Generic;

#nullable disable

namespace PersonasUsuariosAPI.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Email { get; set; }
        public string TipoIdentificacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string CalcId { get; set; }
        public string CalcNombre { get; set; }
    }
}
