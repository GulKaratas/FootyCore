using FootyCore.BusinessLayer.Abstract;
using FootyCore.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
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
        public IActionResult SeasonList()
        {
            var value = _seasonService.TGetList();
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteSeason(int id)
        {
            var value = _seasonService.TGetById(id);
            _seasonService.TDelete(value);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddSeason(Season season)
        {
            _seasonService.TInsert(season);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSeason(Season season)
        {
            _seasonService.TUpdate(season);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSeason(int id)
        {
            var value = _seasonService.TGetById(id);
            return Ok(value);
        }

    }
}
