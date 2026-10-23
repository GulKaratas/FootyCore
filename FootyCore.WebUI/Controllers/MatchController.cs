using Microsoft.AspNetCore.Mvc;

namespace FootyCore.WebUI.Controllers
{
    public class MatchController : Controller
    {
        public IActionResult MatchList()
        {
            return View();
        }
    }
}
