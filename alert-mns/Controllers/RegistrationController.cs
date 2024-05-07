using Microsoft.AspNetCore.Mvc;

namespace alert_mns.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
