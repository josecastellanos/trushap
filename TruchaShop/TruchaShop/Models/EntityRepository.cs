using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TruchaShop.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioPrimerNombre { get; set; }
        public string UsuarioSegundoNombre { get; set; }
        public string UsuarioPrimerApellido { get; set; }
        public string UsuarioSegundoApellido { get; set; }
        public string UsuarioEmail { get; set; }
        public string UsuarioContrasenia { get; set; }
        public DateTime UsuarioFechaAfiliacion { get; set; }

        public string ObtenerNombreCompleto()
        {
            return UsuarioPrimerNombre + " " + UsuarioSegundoNombre + " " + UsuarioPrimerApellido + " " + UsuarioSegundoApellido;
        }
    }
}