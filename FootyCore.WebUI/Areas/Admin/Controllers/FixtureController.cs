using FootyCore.DtoLayer.MatchDto;
using FootyCore.DtoLayer.MatchStatusDto;
using FootyCore.DtoLayer.StadiumDto;
using FootyCore.DtoLayer.TeamDto;
using FootyCore.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FootyCore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FixtureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FixtureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7121/api/Match");
            if (!response.IsSuccessStatusCode)
            {
                return View(new List<ResultMatchDto>());
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMatchDto>>(jsonData);
            return View(values ?? new List<ResultMatchDto>());
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7121/api/Match/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var statuses = await GetStatusesAsync();
            return View(new FixtureFormViewModel
            {
                StatusName = statuses.FirstOrDefault(x => x.StatusName == "Oynanmadı")?.StatusName
                    ?? statuses.FirstOrDefault()?.StatusName
                    ?? "",
                Teams = await GetTeamsAsync(),
                Stadiums = await GetStadiumsAsync(),
                Statuses = statuses
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(FixtureFormViewModel form)
        {
            var statuses = await GetStatusesAsync();
            form.StatusName = ResolveStatus(form.MatchDate, form.StatusName, statuses);
            form.HomeLogoUrl ??= "";
            form.AwayLogoUrl ??= "";

            var dto = new CreateMatchDto
            {
                Week = form.Week ?? 0,
                MatchDate = form.MatchDate ?? default,
                HomeTeamName = form.HomeTeamName,
                AwayTeamName = form.AwayTeamName,
                HomeLogoUrl = form.HomeLogoUrl,
                AwayLogoUrl = form.AwayLogoUrl,
                StadiumName = form.StadiumName,
                StatusName = form.StatusName
            };

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7121/api/Match", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            form.Teams = await GetTeamsAsync();
            form.Stadiums = await GetStadiumsAsync();
            form.Statuses = statuses;
            return View(form);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7121/api/Match/" + id + "/details");
            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultMatchDto>(jsonData);
            if (value == null)
            {
                return RedirectToAction("Index");
            }

            return View(new FixtureFormViewModel
            {
                MatchId = value.MatchId,
                Week = value.Week,
                MatchDate = value.MatchDate,
                HomeTeamName = value.HomeTeamName,
                AwayTeamName = value.AwayTeamName,
                HomeLogoUrl = value.HomeLogoUrl,
                AwayLogoUrl = value.AwayLogoUrl,
                StadiumName = value.StadiumName,
                StatusName = value.StatusName,
                HomeScore = value.HomeScore,
                AwayScore = value.AwayScore,
                Teams = await GetTeamsAsync(),
                Stadiums = await GetStadiumsAsync(),
                Statuses = await GetStatusesAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMatchDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7121/api/Match", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Update", new { id = dto.MatchId });
        }

        private static string ResolveStatus(DateTime? matchDate, string statusName, List<ResultMatchStatusDto> statuses)
        {
            var finished = statuses.FirstOrDefault(x => x.StatusName == "Bitti")?.StatusName;
            var notPlayed = statuses.FirstOrDefault(x => x.StatusName == "Oynanmadı")?.StatusName
                ?? statuses.FirstOrDefault()?.StatusName
                ?? "";

            if (matchDate.HasValue && matchDate.Value < DateTime.Now)
            {
                if (string.IsNullOrWhiteSpace(statusName) || statusName == "Oynanmadı" || statusName == "Yaklaşan")
                {
                    return finished ?? statusName ?? notPlayed;
                }
            }

            return string.IsNullOrWhiteSpace(statusName) ? notPlayed : statusName;
        }

        private async Task<List<ResultTeamDto>> GetTeamsAsync()
        {
            return await GetListAsync<ResultTeamDto>("https://localhost:7121/api/Team");
        }

        private async Task<List<ResultStadiumDto>> GetStadiumsAsync()
        {
            return await GetListAsync<ResultStadiumDto>("https://localhost:7121/api/Stadium");
        }

        private async Task<List<ResultMatchStatusDto>> GetStatusesAsync()
        {
            var values = await GetListAsync<ResultMatchStatusDto>("https://localhost:7121/api/MatchStatus");
            return values
                .Where(x => !string.IsNullOrWhiteSpace(x.StatusName))
                .GroupBy(x => x.StatusName)
                .Select(x => x.First())
                .ToList();
        }

        private async Task<List<T>> GetListAsync<T>(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return new List<T>();
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<T>>(jsonData) ?? new List<T>();
        }
    }
}
