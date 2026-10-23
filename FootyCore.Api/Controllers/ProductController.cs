//using FootyCore.Api.Context;
//using FootyCore.Api.Entities;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//using Microsoft.EntityFrameworkCore;
//using FootyCore.Api.Dtos.ProductDto;

//namespace FootyCore.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductController : ControllerBase
//    {
//        private readonly ApiContext _context;

//        public ProductController(ApiContext context) {
        
//            _context = context;
//        }

//        [HttpGet]
//        public IActionResult ProductList()
//        {
//            var value = _context.Products.Include(x => x.Category).Select(x => new ResultProductDto
//            {

//                ProductId = x.ProductId,
//                ProductName = x.ProductName,
//                Stock = x.Stock,
//                Price = x.Price,
//                CategoryId = x.CategoryId,
//                CategoryName = x.Category.CategoryName
//            }).ToList();

//            return Ok(value);
//        }

//        [HttpPost]

//        public IActionResult CreateProduct(CreateProductDto dto)
//        {
//            var product = new Product
//            {
//                Price = dto.Price,
//                CategoryId = dto.CategoryId,
//                ProductName = dto.ProductName,
//                Stock = dto.Stock
//            };
//            _context.Products.Add(product);
//            _context.SaveChanges();
//            return Ok("Ürün Eklendi");
//        }

//        [HttpDelete]
//        public IActionResult DeleteProduct(int id) { 
        
//            var value = _context.Products.Find(id);
//            _context.Products.Remove(value);
//            _context.SaveChanges();
//            return Ok("Müşteri Silindi");

//         }
//        [HttpGet("GetProduct")]

//        public IActionResult GetProduct(int id) {

//            var value = _context.Products.Find(id);
//            return Ok(value);
//        }

//        [HttpPut]
//        public IActionResult UpdateProduct(UpdateProductDto dto)
//        {
//            var value = _context.Products.Find(dto.ProductId);

//            value.ProductName = dto.ProductName;
//            value.Stock = dto.Stock;
//            value.Price = dto.Price;
//            value.CategoryId = dto.CategoryId;

//            _context.SaveChanges();

//            return Ok("Ürün Güncellendi");
//        }

//    }
//}
