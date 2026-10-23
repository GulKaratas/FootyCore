using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FootyCore.BusinessLayer.Abstract;
using FootyCore.EntityLayer.Entities;
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
        public IActionResult LeagueList()
        {
            var value = _leagueService.TGetList();
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteLeague(int id)
        {
            var value = _leagueService.TGetById(id);
            _leagueService.TDelete(value);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddLeague(League league)
        {
            _leagueService.TInsert(league);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateLeague(League league)
        {
            _leagueService.TUpdate(league);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetLeague(int id) 
        {
            var value = _leagueService.TGetById(id);
            return Ok(value);
        }
        
    }
}
