using FootyCore.DtoLayer.SeasonDto;
using FootyCore.DtoLayer.StandingDto;
using FootyCore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FootyCore.WebUI.Controllers
{
    public class StandingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StandingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> StandingList(int? seasonId)
        {
            var client = _httpClientFactory.CreateClient();
            var seasons = new List<ResultSeasonDto>();

            var seasonResponse = await client.GetAsync("https://localhost:7121/api/Season");
            if (seasonResponse.IsSuccessStatusCode)
            {
                var seasonJson = await seasonResponse.Content.ReadAsStringAsync();
                seasons = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(seasonJson)
                          ?? new List<ResultSeasonDto>();
            }

            var selectedSeasonId = seasonId
                                   ?? seasons.FirstOrDefault(x => x.IsActive)?.SeasonId
                                   ?? seasons.FirstOrDefault()?.SeasonId
                                   ?? 0;

            var page = new ResultStandingPageDto { Standings = new List<ResultStandingDto>() };
            var standingResponse = await client.GetAsync(
                $"https://localhost:7121/api/Standing/season/{selectedSeasonId}");

            if (standingResponse.IsSuccessStatusCode)
            {
                var standingJson = await standingResponse.Content.ReadAsStringAsync();
                page = JsonConvert.DeserializeObject<ResultStandingPageDto>(standingJson) ?? page;
            }

            var seasonName = seasons.FirstOrDefault(x => x.SeasonId == selectedSeasonId)?.SeasonName ?? "";

            var model = new StandingPageViewModel
            {
                SeasonName = seasonName,
                Week = page.Week,
                FeaturedText = page.FeaturedText,
                FeaturedStadium = page.FeaturedStadium,
                Standings = page.Standings ?? new List<ResultStandingDto>()
            };

            return View(model);
        }
    }
}