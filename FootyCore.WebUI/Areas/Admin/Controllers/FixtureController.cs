using Microsoft.AspNetCore.Mvc;

namespace FootyCore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FixtureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
