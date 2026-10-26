using FootyCore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FootyCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandingController : ControllerBase
    {
        private readonly IStandingService _standingService;

        public StandingController(IStandingService standingService)
        {
            _standingService = standingService;
        }

        [HttpGet("season/{seasonId}")]
        public async Task<IActionResult> GetStandingsBySeason(int seasonId)
        {
            var value = await _standingService.GetStandingsBySeasonAsync(seasonId);
            return Ok(value);
        }
    }
}