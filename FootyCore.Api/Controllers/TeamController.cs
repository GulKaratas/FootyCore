using FootyCore.BusinessLayer.Abstract;
using FootyCore.DtoLayer.TeamDto;
using Microsoft.AspNetCore.Mvc;

namespace FootyCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> TeamList()
        {
            var value = await _teamService.TGetList();
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.TDelete(id);
            return Ok("Takım Başarıyla Silindi");
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(CreateTeamDto dto)
        {
            await _teamService.TInsert(dto);
            return Ok("Takım Başarıyla Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto dto)
        {
            await _teamService.TUpdate(dto);
            return Ok("Takım Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var value = await _teamService.TGetById(id);
            return Ok(value);
        }
    }
}
