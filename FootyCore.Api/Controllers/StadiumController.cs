using FootyCore.BusinessLayer.Abstract;
using FootyCore.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
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
        public IActionResult StadiumList()
        {
            var value = _stadiumService.TGetList();
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteStadium(int id)
        {
            var value = _stadiumService.TGetById(id);
            _stadiumService.TDelete(value);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddStadium(Stadium stadium)
        {
            _stadiumService.TInsert(stadium);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateStadium(Stadium stadium)
        {
            _stadiumService.TUpdate(stadium);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetStadium(int id)
        {
            var value = _stadiumService.TGetById(id);
            return Ok(value);
        }

    }
}
