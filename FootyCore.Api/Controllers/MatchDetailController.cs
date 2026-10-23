using FootyCore.BusinessLayer.Abstract;
using FootyCore.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
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
        public IActionResult MatchDetailList()
        {
            var value = _matchDetailService.TGetList();
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteMatchDetail(int id)
        {
            var value = _matchDetailService.TGetById(id);
            _matchDetailService.TDelete(value);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddMatchDetail(MatchDetail matchDetail)
        {
            _matchDetailService.TInsert(matchDetail);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMatchDetail(MatchDetail matchDetail)
        {
            _matchDetailService.TUpdate(matchDetail);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetMatchDetail(int id)
        {
            var value = _matchDetailService.TGetById(id);
            return Ok(value);
        }

    }
}
