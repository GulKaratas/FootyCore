using FootyCore.BusinessLayer.Abstract;
using FootyCore.DtoLayer.LeagueDto;
using Microsoft.AspNetCore.Mvc;

namespace FootyCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService _leagueService;

        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet]
        public async Task<IActionResult> LeagueList()
        {
            var value = await _leagueService.TGetList();
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeague(int id)
        {
            await _leagueService.TDelete(id);
            return Ok("Lig Başarıyla Silindi");
        }

        [HttpPost]
        public async Task<IActionResult> AddLeague(CreateLeagueDto dto)
        {
            await _leagueService.TInsert(dto);
            return Ok("Lig Başarıyla Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLeague(UpdateLeagueDto dto)
        {
            await _leagueService.TUpdate(dto);
            return Ok("Lig Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeague(int id)
        {
            var value = await _leagueService.TGetById(id);
            return Ok(value);
        }
    }
}
