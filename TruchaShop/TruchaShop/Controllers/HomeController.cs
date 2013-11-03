using System.Web.Mvc;

namespace TruchaShop.Controllers {
  public class HomeController : Controller {
    public ActionResult Index() {
      return View();
    }
  }
}