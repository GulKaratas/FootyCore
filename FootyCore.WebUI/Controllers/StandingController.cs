using Microsoft.AspNetCore.Mvc;

namespace FootyCore.WebUI.Controllers
{
    public class StandingController : Controller
    {
        public IActionResult StandingList()
        {
            return View();
        }
    }
}
