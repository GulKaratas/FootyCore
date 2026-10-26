using System.Globalization;
using FootyCore.DtoLayer.MatchDetailDto;
using FootyCore.DtoLayer.MatchDto;
using FootyCore.DtoLayer.SeasonDto;
using FootyCore.WebUI.Models;
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

        public async Task<IActionResult> MatchList(int? seasonId, int? week)
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
            var matchResponse = await client.GetAsync(
                $"https://localhost:7121/api/Match/season/{selectedSeasonId}/week/{selectedWeek}");

            if (matchResponse.IsSuccessStatusCode)
            {
                var matchJson = await matchResponse.Content.ReadAsStringAsync();
                matches = JsonConvert.DeserializeObject<List<ResultMatchDto>>(matchJson)
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
                DateRange = BuildDateRange(matches, culture),
                FeaturedMatch = matches.FirstOrDefault()
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

        public async Task<IActionResult> MatchDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7121/api/Match/{id}/details");

            var page = new ResultMatchDto();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                page = JsonConvert.DeserializeObject<ResultMatchDto>(json) ?? page;
            }

            var model = new MatchDetailsViewModel
            {
                Match = page,
                Details = (page.Details ?? new List<ResultMatchDetailDto>()).OrderBy(x => x.Minute).ToList(),
                Statistic = page.Statistic
            };

            model.Goals = model.Details.Where(x => x.ActionType == "Gol").ToList();
            model.Cards = model.Details.Where(x => x.ActionType == "Sarı Kart" || x.ActionType == "Kırmızı Kart").ToList();
            model.Substitutions = model.Details.Where(x => x.ActionType == "Değişiklik").ToList();

            return View(model);
        }
    }
}
