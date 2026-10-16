using FootyCore.Api.Context;
using FootyCore.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootyCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApiContext _context;

        public ProductController(ApiContext context) {
        
            _context = context;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _context.Products.ToList();
            return Ok(value);
        }

        [HttpPost]

        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok("Ürün Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id) { 
        
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return Ok("Müşteri Silindi");

         }
        [HttpGet("GetProduct")]

        public IActionResult GetProduct(int id) {

            var value = _context.Products.Find(id);
            return Ok(value);
        }
        [HttpPut]

        public IActionResult UpdateSProduct(Product product) { 
        
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok("Ürün Güncellendi");
        }
    }
}
