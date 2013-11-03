using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Omu.ValueInjecter;
using TruchaShop.Models;

namespace TruchaShop.Controllers
{
    public class UsuarioController : Controller
    {
        TruchaShopContext context;
        
        public UsuarioController()
        {
            try
            {
                context = new TruchaShopContext();
            }
            catch (Exception e)
            {
                var ex = e.ToString();
            }
        }

        public JsonResult Login(LoginRequestModel login)
        {
            var userEntity = context.Usuarios.FirstOrDefault(m => m.UsuarioNombre == login.Username);
            var result = new LoginResponseModel()
                {
                    NombreCompleto = "",
                    PrimerNombre = "",
                    Success = false
                };

            if (userEntity != null)
            {
                if (userEntity.UsuarioContrasenia == login.Password)
                {
                    result.NombreCompleto = userEntity.ObtenerNombreCompleto();
                    result.PrimerNombre = userEntity.UsuarioPrimerNombre;
                    result.Success = true;
                }
            }
            
            return this.Json(result);
        }
    }
}
