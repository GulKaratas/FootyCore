using FootyCore.DtoLayer.MatchDetailDto;
using FootyCore.DtoLayer.MatchDto;
using FootyCore.DtoLayer.TeamDto;
using FootyCore.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FootyCore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MatchDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MatchDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7121/api/MatchDetail");
            if (!response.IsSuccessStatusCode)
            {
                return View(new MatchEventPageViewModel());
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var events = JsonConvert.DeserializeObject<List<ResultMatchDetailDto>>(jsonData) ?? new List<ResultMatchDetailDto>();
            var matches = await GetMatchesAsync();
            var featuredId = events
                .GroupBy(x => x.MatchId)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .FirstOrDefault();
            var featured = matches.FirstOrDefault(x => x.MatchId == featuredId) ?? matches.FirstOrDefault();
            return View(new MatchEventPageViewModel
            {
                Events = events,
                Featured = featured
            });
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var matches = await GetMatchesAsync();
            var teams = await GetTeamsAsync();
            return View(new MatchEventFormViewModel
            {
                Matches = matches,
                Teams = teams
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMatchDetailDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7121/api/MatchDetail", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(new MatchEventFormViewModel
            {
                MatchId = dto.MatchId,
                TeamId = dto.TeamId,
                ActionType = dto.ActionType,
                Description = dto.Description,
                Minute = dto.Minute,
                Matches = await GetMatchesAsync(),
                Teams = await GetTeamsAsync()
            });
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7121/api/MatchDetail/" + id);
            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateMatchDetailDto>(jsonData);
            if (value == null)
            {
                return RedirectToAction("Index");
            }

            return View(new MatchEventFormViewModel
            {
                MatchDetailId = value.MatchDetailId,
                MatchId = value.MatchId,
                TeamId = value.TeamId,
                ActionType = value.ActionType,
                Description = value.Description,
                Minute = value.Minute,
                Matches = await GetMatchesAsync(),
                Teams = await GetTeamsAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMatchDetailDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7121/api/MatchDetail", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Update", new { id = dto.MatchDetailId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7121/api/MatchDetail/" + id);
            return RedirectToAction("Index");
        }

        private async Task<List<ResultMatchDto>> GetMatchesAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7121/api/Match");
            if (!response.IsSuccessStatusCode)
            {
                return new List<ResultMatchDto>();
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ResultMatchDto>>(jsonData) ?? new List<ResultMatchDto>();
        }

        private async Task<List<ResultTeamDto>> GetTeamsAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7121/api/Team");
            if (!response.IsSuccessStatusCode)
            {
                return new List<ResultTeamDto>();
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ResultTeamDto>>(jsonData) ?? new List<ResultTeamDto>();
        }
    }
}
