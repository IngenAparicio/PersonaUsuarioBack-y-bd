﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PersonasUsuariosAPI.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Usuario1 { get; set; }
        public string Pass { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
