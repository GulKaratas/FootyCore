using FootyCore.DtoLayer.MatchDto;
using FootyCore.DtoLayer.MatchStatisticDto;
using FootyCore.DtoLayer.MatchStatusDto;
using FootyCore.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FootyCore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MatchController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MatchController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            return View(await GetMatchesAsync());
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7121/api/Match/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var matches = await GetMatchesAsync();
            var first = matches.FirstOrDefault();
            var statuses = await GetStatusesAsync();
            return View(new ScoreFormViewModel
            {
                MatchId = first?.MatchId ?? 0,
                HomeTeamName = first?.HomeTeamName,
                AwayTeamName = first?.AwayTeamName,
                StadiumName = first?.StadiumName,
                Week = first?.Week ?? 0,
                StatusName = string.IsNullOrWhiteSpace(first?.StatusName) ? statuses.FirstOrDefault()?.StatusName : first.StatusName,
                HomeLogoUrl = first?.HomeLogoUrl,
                AwayLogoUrl = first?.AwayLogoUrl,
                Matches = matches,
                Statuses = statuses
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ScoreFormViewModel form)
        {
            if (await SaveAsync(form))
            {
                return RedirectToAction("Index");
            }

            form.Matches = await GetMatchesAsync();
            form.Statuses = await GetStatusesAsync();
            return View(form);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var match = await GetMatchAsync(id);
            if (match == null)
            {
                return RedirectToAction("Index");
            }

            var form = ToForm(match, await GetMatchesAsync());
            form.Statuses = await GetStatusesAsync();
            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ScoreFormViewModel form)
        {
            if (await SaveAsync(form))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Update", new { id = form.MatchId });
        }

        private async Task<bool> SaveAsync(ScoreFormViewModel form)
        {
            var match = await GetMatchAsync(form.MatchId);
            if (match == null)
            {
                return false;
            }

            var client = _httpClientFactory.CreateClient();
            var update = new UpdateMatchDto
            {
                MatchId = match.MatchId,
                Week = match.Week,
                MatchDate = match.MatchDate,
                HomeTeamName = match.HomeTeamName,
                AwayTeamName = match.AwayTeamName,
                HomeLogoUrl = match.HomeLogoUrl ?? "",
                AwayLogoUrl = match.AwayLogoUrl ?? "",
                StadiumName = match.StadiumName,
                StatusName = string.IsNullOrWhiteSpace(form.StatusName) ? match.StatusName : form.StatusName,
                HomeScore = form.HomeScore,
                AwayScore = form.AwayScore
            };

            var matchContent = new StringContent(JsonConvert.SerializeObject(update), Encoding.UTF8, "application/json");
            var matchResponse = await client.PutAsync("https://localhost:7121/api/Match", matchContent);
            if (!matchResponse.IsSuccessStatusCode)
            {
                return false;
            }

            if (match.Statistic == null)
            {
                var create = new CreateMatchStatisticDto
                {
                    MatchId = form.MatchId,
                    HomeFirstHalfGoals = form.HomeFirstHalfGoals,
                    AwayFirstHalfGoals = form.AwayFirstHalfGoals,
                    HomeSecondHalfGoals = form.HomeSecondHalfGoals,
                    AwaySecondHalfGoals = form.AwaySecondHalfGoals,
                    HomeShots = form.HomeShots,
                    AwayShots = form.AwayShots,
                    HomeShotsOnTarget = form.HomeShotsOnTarget,
                    AwayShotsOnTarget = form.AwayShotsOnTarget,
                    HomePossession = form.HomePossession,
                    AwayPossession = form.AwayPossession
                };
                var content = new StringContent(JsonConvert.SerializeObject(create), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7121/api/MatchStatistic", content);
                return response.IsSuccessStatusCode;
            }

            var statistic = new UpdateMatchStatisticDto
            {
                MatchStatisticId = match.Statistic.MatchStatisticId,
                MatchId = form.MatchId,
                HomeFirstHalfGoals = form.HomeFirstHalfGoals,
                AwayFirstHalfGoals = form.AwayFirstHalfGoals,
                HomeSecondHalfGoals = form.HomeSecondHalfGoals,
                AwaySecondHalfGoals = form.AwaySecondHalfGoals,
                HomeShots = form.HomeShots,
                AwayShots = form.AwayShots,
                HomeShotsOnTarget = form.HomeShotsOnTarget,
                AwayShotsOnTarget = form.AwayShotsOnTarget,
                HomePossession = form.HomePossession,
                AwayPossession = form.AwayPossession
            };
            var updateContent = new StringContent(JsonConvert.SerializeObject(statistic), Encoding.UTF8, "application/json");
            var updateResponse = await client.PutAsync("https://localhost:7121/api/MatchStatistic", updateContent);
            return updateResponse.IsSuccessStatusCode;
        }

        private static ScoreFormViewModel ToForm(ResultMatchDto match, List<ResultMatchDto> matches)
        {
            var statistic = match.Statistic;
            return new ScoreFormViewModel
            {
                MatchId = match.MatchId,
                MatchStatisticId = statistic?.MatchStatisticId ?? 0,
                HomeTeamName = match.HomeTeamName,
                AwayTeamName = match.AwayTeamName,
                HomeLogoUrl = match.HomeLogoUrl,
                AwayLogoUrl = match.AwayLogoUrl,
                StadiumName = match.StadiumName,
                Week = match.Week,
                StatusName = match.StatusName,
                HomeScore = match.HomeScore,
                AwayScore = match.AwayScore,
                HomeFirstHalfGoals = statistic?.HomeFirstHalfGoals ?? 0,
                AwayFirstHalfGoals = statistic?.AwayFirstHalfGoals ?? 0,
                HomeSecondHalfGoals = statistic?.HomeSecondHalfGoals ?? 0,
                AwaySecondHalfGoals = statistic?.AwaySecondHalfGoals ?? 0,
                HomeShots = statistic?.HomeShots ?? 0,
                AwayShots = statistic?.AwayShots ?? 0,
                HomeShotsOnTarget = statistic?.HomeShotsOnTarget ?? 0,
                AwayShotsOnTarget = statistic?.AwayShotsOnTarget ?? 0,
                HomePossession = statistic?.HomePossession ?? 0,
                AwayPossession = statistic?.AwayPossession ?? 0,
                Matches = matches
            };
        }

        private async Task<ResultMatchDto> GetMatchAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7121/api/Match/" + id + "/details");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResultMatchDto>(jsonData);
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

        private async Task<List<ResultMatchStatusDto>> GetStatusesAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7121/api/MatchStatus");
            if (!response.IsSuccessStatusCode)
            {
                return new List<ResultMatchStatusDto>();
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMatchStatusDto>>(jsonData) ?? new List<ResultMatchStatusDto>();
            return values
                .Where(x => !string.IsNullOrWhiteSpace(x.StatusName))
                .GroupBy(x => x.StatusName)
                .Select(x => x.First())
                .ToList();
        }
    }
}
