using Microsoft.AspNetCore.Mvc;

namespace FootyCore.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult _IndexLayout()
        {
            return View();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult TopbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult FilterPartial()
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
    }
}
