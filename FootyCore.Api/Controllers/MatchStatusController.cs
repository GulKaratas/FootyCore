using FootyCore.BusinessLayer.Abstract;
using FootyCore.DtoLayer.MatchStatusDto;
using Microsoft.AspNetCore.Mvc;

namespace FootyCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchStatusController : ControllerBase
    {
        private readonly IMatchStatusService _matchStatusService;

        public MatchStatusController(IMatchStatusService matchStatusService)
        {
            _matchStatusService = matchStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> MatchStatusList()
        {
            var value = await _matchStatusService.TGetList();
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatchStatus(int id)
        {
            await _matchStatusService.TDelete(id);
            return Ok("Maç Durumları Başarıyla Silindi");
        }

        [HttpPost]
        public async Task<IActionResult> AddMatchStatus(CreateMatchStatusDto dto)
        {
            await _matchStatusService.TInsert(dto);
            return Ok("Maç Durumları Başarıyla Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMatchStatus(UpdateMatchStatusDto dto)
        {
            await _matchStatusService.TUpdate(dto);
            return Ok("Maç Durumları Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchStatus(int id)
        {
            var value = await _matchStatusService.TGetById(id);
            return Ok(value);
        }
    }
}
