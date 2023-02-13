using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Models;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _context;
        public ProductsController(ShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Product>> GetAllProducts()
        //{
        //    return Ok(_context.Products.ToArray());
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _context.Products.ToArrayAsync();
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
