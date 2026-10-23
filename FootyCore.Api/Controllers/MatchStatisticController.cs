using FootyCore.BusinessLayer.Abstract;
using FootyCore.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
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
        public IActionResult MatchStatisticList()
        {
            var value = _matchStatisticService.TGetList();
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteMatchStatistic(int id)
        {
            var value = _matchStatisticService.TGetById(id);
            _matchStatisticService.TDelete(value);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddMatchStatistic(MatchStatistic matchStatistic)
        {
            _matchStatisticService.TInsert(matchStatistic);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMatchStatistic(MatchStatistic matchStatistic)
        {
            _matchStatisticService.TUpdate(matchStatistic);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetMatchStatistic(int id)
        {
            var value = _matchStatisticService.TGetById(id);
            return Ok(value);
        }

    }
}
