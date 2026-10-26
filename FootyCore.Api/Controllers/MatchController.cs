using FootyCore.BusinessLayer.Abstract;
using FootyCore.DtoLayer.MatchDto;
using Microsoft.AspNetCore.Mvc;

namespace FootyCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IMatchDetailService _matchDetailService;

        public MatchController(IMatchService matchService, IMatchDetailService matchDetailService)
        {
            _matchService = matchService;
            _matchDetailService = matchDetailService;
        }


        [HttpGet("season/{seasonId}/week/{week}")]
        public async Task<IActionResult> GetMatchesBySeasonAndWeek(int seasonId, int week)
        {
            var value = await _matchService.GetMatchesBySeasonAndWeekAsync(seasonId, week);
            return Ok(value);
        }

        [HttpGet]
        public async Task<IActionResult> MatchList()
        {
            var value = await _matchService.TGetList();
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            await _matchService.TDelete(id);
            return Ok("Maç Başarıyla Silindi");
        }

        [HttpPost]
        public async Task<IActionResult> AddMatch(CreateMatchDto dto)
        {
            await _matchService.TInsert(dto);
            return Ok("Maç Başarıyla Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMatch(UpdateMatchDto dto)
        {
            await _matchService.TUpdate(dto);
            return Ok("Maç Başarıyla Güncellendi");
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetMatchDetails(int id)
        {
            var match = await _matchService.GetMatchDetailsByIdAsync(id);
            if (match == null)
                return NotFound();

            match.Details = await _matchDetailService.GetDetailsByMatchIdAsync(id);
            return Ok(match);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatch(int id)
        {
            var value = await _matchService.TGetById(id);
            return Ok(value);
        }

       
    }
}
