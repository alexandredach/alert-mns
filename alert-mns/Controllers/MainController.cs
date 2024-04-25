using Microsoft.AspNetCore.Mvc;

namespace alert_mns.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
