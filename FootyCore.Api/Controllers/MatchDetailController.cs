using FootyCore.BusinessLayer.Abstract;
using FootyCore.DtoLayer.MatchDetailDto;
using Microsoft.AspNetCore.Mvc;

namespace FootyCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchDetailController : ControllerBase
    {
        private readonly IMatchDetailService _matchDetailService;

        public MatchDetailController(IMatchDetailService matchDetailService)
        {
            _matchDetailService = matchDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> MatchDetailList()
        {
            var value = await _matchDetailService.TGetList();
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatchDetail(int id)
        {
            await _matchDetailService.TDelete(id);
            return Ok("Maç Detayları Başarıyla Silindi");
        }

        [HttpPost]
        public async Task<IActionResult> AddMatchDetail(CreateMatchDetailDto dto)
        {
            await _matchDetailService.TInsert(dto);
            return Ok("Maç Detayları Başarıyla Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMatchDetail(UpdateMatchDetailDto dto)
        {
            await _matchDetailService.TUpdate(dto);
            return Ok("Maç Detayları Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchDetail(int id)
        {
            var value = await _matchDetailService.TGetById(id);
            return Ok(value);
        }
    }
}
