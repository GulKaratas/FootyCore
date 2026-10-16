using FootyCore.Api.Context;
using FootyCore.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootyCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApiContext _context;

        public CategoryController(ApiContext context) { 
        
            _context = context;
        }

        [HttpGet]
        public IActionResult CategoryList() {

            var value = _context.Categories.ToList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategori Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id) {

            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Silme Başarılı");
        }

        [HttpGet("GetCategory")]

        public IActionResult GetCategory(int id) {

            var value = _context.Categories.Find(id);
            return Ok(value);
        }

        [HttpPut]

        public IActionResult UpdateCategory(Category category)
        {
            var value = _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Güncelleme Başarılı");
        }
    }
}
