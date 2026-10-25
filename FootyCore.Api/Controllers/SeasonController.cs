using FootyCore.BusinessLayer.Abstract;
using FootyCore.DtoLayer.SeasonDto;
using Microsoft.AspNetCore.Mvc;

namespace FootyCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonService _seasonService;

        public SeasonController(ISeasonService seasonService)
        {
            _seasonService = seasonService;
        }

        [HttpGet]
        public async Task<IActionResult> SeasonList()
        {
            var value = await _seasonService.TGetList();
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeason(int id)
        {
            await _seasonService.TDelete(id);
            return Ok("Sezon Başarıyla Silindi");
        }

        [HttpPost]
        public async Task<IActionResult> AddSeason(CreateSeasonDto dto)
        {
            await _seasonService.TInsert(dto);
            return Ok("Sezon Başarıyla Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSeason(UpdateSeasonDto dto)
        {
            await _seasonService.TUpdate(dto);
            return Ok("Sezon Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeason(int id)
        {
            var value = await _seasonService.TGetById(id);
            return Ok(value);
        }
    }
}
