using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public JsonResult Login(LoginRequestModel login)
        {
            var meetingEntity = context.ProductosCompania.
            var meetingModel = new MeetingModel();
            if (meetingEntity != null)
            {
                meetingModel.InjectFrom(meetingEntity);
                meetingModel.Attendees = meetingEntity.Attendees.Select(a => a.Name).ToArray();
            }
            return this.Json(meetingModel);
        }

    }
}
