using System.Globalization;
using FootyCore.DtoLayer.MatchDto;
using FootyCore.DtoLayer.SeasonDto;
using FootyCore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FootyCore.WebUI.Controllers
{
    public class FixtureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FixtureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> FixtureList(int? seasonId, int? week)
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

            var selectedWeek = week ?? 1;

            var matches = new List<ResultMatchDto>();
            var fixtureResponse = await client.GetAsync(
                $"https://localhost:7121/api/Fixture/season/{selectedSeasonId}/week/{selectedWeek}");

            if (fixtureResponse.IsSuccessStatusCode)
            {
                var fixtureJson = await fixtureResponse.Content.ReadAsStringAsync();
                matches = JsonConvert.DeserializeObject<List<ResultMatchDto>>(fixtureJson)
                          ?? new List<ResultMatchDto>();
            }

            var culture = new CultureInfo("tr-TR");
            var model = new MatchPageViewModel
            {
                Matches = matches,
                Seasons = seasons,
                SelectedSeasonId = selectedSeasonId,
                SelectedWeek = selectedWeek,
                LeagueName = matches.Select(x => x.LeagueName).FirstOrDefault(x => !string.IsNullOrWhiteSpace(x)) ?? "Premier League",
                DateRange = BuildDateRange(matches, culture)
            };

            return View(model);
        }

        private static string BuildDateRange(List<ResultMatchDto> matches, CultureInfo culture)
        {
            if (matches.Count == 0)
                return "Bu haftada maç yok";

            var min = matches.Min(x => x.MatchDate);
            var max = matches.Max(x => x.MatchDate);
            if (min.Date == max.Date)
                return min.ToString("dd MMMM yyyy", culture);

            return $"{min.ToString("dd MMMM", culture)} – {max.ToString("dd MMMM yyyy", culture)}";
        }
    }
}
