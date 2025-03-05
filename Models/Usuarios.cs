// Models/Usuarios.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace IT_LiquidacionFacturas.Models
{
    public class Usuario
    {
        public long IdUsuario { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string UsuarioNombre { get; set; }

        [Required]
        public byte[] Contrasena { get; set; }

        public int IdRol { get; set; }

        public DateTime FechaCrea { get; set; }

        public DateTime FechaModifica { get; set; }

        public bool Estado { get; set; }
    }
}