using FootyCore.BusinessLayer.Abstract;
using FootyCore.DtoLayer.StadiumDto;
using Microsoft.AspNetCore.Mvc;

namespace FootyCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly IStadiumService _stadiumService;

        public StadiumController(IStadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        [HttpGet]
        public async Task<IActionResult> StadiumList()
        {
            var value = await _stadiumService.TGetList();
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStadium(int id)
        {
            await _stadiumService.TDelete(id);
            return Ok("Stadyum Başarıyla Silindi");
        }

        [HttpPost]
        public async Task<IActionResult> AddStadium(CreateStadiumDto dto)
        {
            await _stadiumService.TInsert(dto);
            return Ok("Stadyum Başarıyla Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStadium(UpdateStadiumDto dto)
        {
            await _stadiumService.TUpdate(dto);
            return Ok("Stadyum Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStadium(int id)
        {
            var value = await _stadiumService.TGetById(id);
            return Ok(value);
        }
    }
}
