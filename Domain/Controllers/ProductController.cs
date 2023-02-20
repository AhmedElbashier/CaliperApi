using Microsoft.AspNetCore.Mvc;
using CaliperApi.Domain.Helpers;
using CaliperApi.Domain.Services;
using CaliperApi.Domain.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Linq;

namespace CaliperApi.Domain.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IProductService _ProductService;

        public ProductController(AppDbContext context, IProductService ProductService)
        {
            _context = context;
            _ProductService = ProductService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var Products = _ProductService.GetALl();
            return Ok(Products);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var Product = _ProductService.GetProduct(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Ok(Product);
        }

            [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product Product)
        {
            if (id != Product.id)
            {
                return BadRequest();
            }

            _context.Entry(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public IActionResult CreateProduct(ProductDto ProductDto)
        {
            var Product = _ProductService.CreateProduct(ProductDto);
            return Ok(Product);
        }

                private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.id == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var Product = await _context.Products.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();

            return Product;
        }
    }
}