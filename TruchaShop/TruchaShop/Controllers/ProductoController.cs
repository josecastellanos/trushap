using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Omu.ValueInjecter;
using TruchaShop.Models;

namespace TruchaShop.Controllers
{
    public class ProductoController : Controller
    {
        TruchaShopContext context;

        public ProductoController()
        {
            context = new TruchaShopContext();
        }

        public JsonResult ObtenerProductos()
        {
            var productos = context.ProductosCompania.ToList();
            var productosModel = productos.Select(e => new ProductoCompaniaModel().InjectFrom(e)).Cast<ProductoCompaniaModel>().ToList();
            return this.Json(productosModel, JsonRequestBehavior.AllowGet);
        }

    }
}
