using AutoMapper;
using IntroCFAPI.DTOs;
using IntroCFAPI.EF;
using IntroCFAPI.EF.Table;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroCFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        PMSContext db;

        public ShopController(PMSContext db)
        {
            this.db = db;
        }
        public Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>().ReverseMap();
            });
            return new Mapper(config);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var products = GetMapper().Map<List<ProductDTO>>(db.Products.ToList());
            return Ok(products);
        }

        [HttpGet("all{id}")]
        public IActionResult GetAll(int id)
        {
            var product = db.Products.Find(id);
            return Ok(product);
        }

        [HttpPost("add")]
        public IActionResult AddProduct(ProductDTO productDto)
        {
            if (ModelState.IsValid)
            {
                var product = GetMapper().Map<Product>(productDto);
                db.Products.Add(product);
                db.SaveChanges();
                return Ok(product);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("Update{id}")]
        public IActionResult UpdateProduct(ProductDTO productDto, int id)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = db.Products.Find(id);
                if (existingProduct == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }
                var updatedProduct = GetMapper().Map<ProductDTO, Product>(productDto, existingProduct);
                db.Products.Add(updatedProduct);
                db.SaveChanges();
                return Ok(updatedProduct);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("Delete{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return Ok(product);

        }
    }
}
