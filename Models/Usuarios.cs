// Models/Usuarios.cs
using System;

namespace IT_LiquidacionFacturas.Models
{
    public class Usuarios
    {
        public long IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UsuarioNombre { get; set; } // Cambiado para evitar confusión con la propiedad 'Usuario'
        public byte[] Contrasena { get; set; }
        public int IdRol { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaModifica { get; set; }
        public bool Estado { get; set; }
    }
}