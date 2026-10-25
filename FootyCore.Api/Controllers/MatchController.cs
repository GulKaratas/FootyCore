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

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatch(int id)
        {
            var value = await _matchService.TGetById(id);
            return Ok(value);
        }

       
    }
}
