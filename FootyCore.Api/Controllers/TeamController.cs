using FootyCore.BusinessLayer.Abstract;
using FootyCore.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
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
        public IActionResult TeamList()
        {
            var value = _teamService.TGetList();
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteTeam(int id)
        {
            var value = _teamService.TGetById(id);
            _teamService.TDelete(value);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            _teamService.TInsert(team);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTeam(Team team)
        {
            _teamService.TUpdate(team);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetTeam(int id)
        {
            var value = _teamService.TGetById(id);
            return Ok(value);
        }

    }
}
