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

    public class ProductoCompania
    {
        [Key]
        public int ProductoId { get; set; }
        [Key]
        public int ProductoCompaniaId { get; set; }
        public string ProductoNombre { get; set; }
        public string ProductoDescripcion { get; set; }
        public DateTime ProductoFecha { get; set; }
        public string ProductoLogo { get; set; }

        public virtual ICollection<Existencia> Existencias { get; set; }

        public int ObtenerPrecioReciente()
        {
            if (Existencias != null && Existencias.Count > 0)
            {
                return Existencias.FirstOrDefault(e => e.ExistenciaFechaAgotado == null && e.ExistenciaDisponible > 0).ExistenciaValor;
            }
            return 0;
        }
    }

    public class Existencia
    {
        [Key]
        public int ExistenciaId { get; set; }
        [Key]
        public int ExistenciaProductoId { get; set; }
        [Key]
        public int ExistenciaProductoCompaniaId { get; set; }
        public int ExistenciaMonto { get; set; }
        public int ExistenciaValor { get; set; }
        public DateTime ExistenciaFechaDisponible { get; set; }
        public int ExistenciaDisponible { get; set; }
        public DateTime? ExistenciaFechaAgotado { get; set; }

        public virtual ProductoCompania ProductoCompania { get; set; }
    }
}