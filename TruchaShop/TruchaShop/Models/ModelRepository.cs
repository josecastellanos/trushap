﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TruchaShop.Models
{
    [DataContract]
    public class UsuarioModel
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string PrimerNombre { get; set; }
        [DataMember]
        public string NombreCompleto { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public DateTime FechaAfiliacion { get; set; }
    }

    [DataContract]
    public class LoginRequestModel
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
    }

    [DataContract]
    public class LoginResponseModel
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string PrimerNombre { get; set; }
        [DataMember]
        public string NombreCompleto { get; set; }
    }

    [DataContract]
    public class ProductoCompaniaModel
    {
        [DataMember]
        public int ProductoId { get; set; }
        [DataMember]
        public string ProductoNombre { get; set; }
        [DataMember]
        public string ProductoDescripcion { get; set; }
        [DataMember]
        public string ProductoLogo { get; set; }
        [DataMember]
        public int Precio { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
    }
}