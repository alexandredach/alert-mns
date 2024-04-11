using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alert_mns.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
