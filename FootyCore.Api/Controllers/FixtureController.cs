using FootyCore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FootyCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixtureController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public FixtureController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet("season/{seasonId}/week/{week}")]
        public async Task<IActionResult> GetFixturesBySeasonAndWeek(int seasonId, int week)
        {
            var value = await _matchService.GetMatchesBySeasonAndWeekAsync(seasonId, week);
            return Ok(value);
        }
    }
}
