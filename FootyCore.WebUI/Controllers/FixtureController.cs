using Microsoft.AspNetCore.Mvc;

namespace FootyCore.WebUI.Controllers
{
    public class FixtureController : Controller
    {
        public IActionResult FixtureList()
        {
            return View();
        }
    }
}
