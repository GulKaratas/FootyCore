using FootyCore.BusinessLayer.Abstract;
using FootyCore.DtoLayer.MatchStatisticDto;
using Microsoft.AspNetCore.Mvc;

namespace FootyCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchStatisticController : ControllerBase
    {
        private readonly IMatchStatisticService _matchStatisticService;

        public MatchStatisticController(IMatchStatisticService matchStatisticService)
        {
            _matchStatisticService = matchStatisticService;
        }

        [HttpGet]
        public async Task<IActionResult> MatchStatisticList()
        {
            var value = await _matchStatisticService.TGetList();
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatchStatistic(int id)
        {
            await _matchStatisticService.TDelete(id);
            return Ok("Maç İstatistikleri Başarıyla Silindi");
        }

        [HttpPost]
        public async Task<IActionResult> AddMatchStatistic(CreateMatchStatisticDto dto)
        {
            await _matchStatisticService.TInsert(dto);
            return Ok("Maç İstatistikleri Başarıyla Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMatchStatistic(UpdateMatchStatisticDto dto)
        {
            await _matchStatisticService.TUpdate(dto);
            return Ok("Maç İstatistikleri Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchStatistic(int id)
        {
            var value = await _matchStatisticService.TGetById(id);
            return Ok(value);
        }
    }
}
