using FootyCore.DtoLayer.MatchDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FootyCore.WebUI.Controllers
{
    public class MatchController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MatchController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MatchList()
        {
            return View();
        }

        public async Task<IActionResult> MatchDetails()
        {
            return View();
        }
    }
}
