using FootyCore.BusinessLayer.Abstract;
using FootyCore.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
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
        public IActionResult MatchList()
        {
            var value = _matchService.TGetList();
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteMatch(int id)
        {
            var value = _matchService.TGetById(id);
            _matchService.TDelete(value);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddMatch(Match match)
        {
            _matchService.TInsert(match);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMatch(Match match)
        {
            _matchService.TUpdate(match);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetMatch(int id)
        {
            var value = _matchService.TGetById(id);
            return Ok(value);
        }

    }
}
