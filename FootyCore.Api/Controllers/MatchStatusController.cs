using FootyCore.BusinessLayer.Abstract;
using FootyCore.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
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
        public IActionResult MatchStatusList()
        {
            var value = _matchStatusService.TGetList();
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteMatchStatus(int id)
        {
            var value = _matchStatusService.TGetById(id);
            _matchStatusService.TDelete(value);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddMatchStatus(MatchStatus matchStatus)
        {
            _matchStatusService.TInsert(matchStatus);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMatchStatus(MatchStatus matchStatus)
        {
            _matchStatusService.TUpdate(matchStatus);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetMatchStatus(int id)
        {
            var value = _matchStatusService.TGetById(id);
            return Ok(value);
        }

    }
}
