using Microsoft.AspNetCore.Mvc;

namespace FootyCore.WebUI.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult _IndexLayout()
        {
            return View();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult TopbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult SidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
    }
}
