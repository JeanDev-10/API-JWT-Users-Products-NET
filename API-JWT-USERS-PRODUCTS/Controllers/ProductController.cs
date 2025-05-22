using API_JWT_USERS_PRODUCTS.Context;
using API_JWT_USERS_PRODUCTS.Models;
using API_JWT_USERS_PRODUCTS.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_JWT_USERS_PRODUCTS.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApiJwtProductsUsersContext _context;
        public ProductController(ApiJwtProductsUsersContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(new { message = "Lista de productos", data = products });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneProducts(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Producto no encontrado" });
            }
            return Ok(new { message = "Lista de productos", data = product });
        }




        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromBody] UpdateProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != product.Id)
            {
                return BadRequest();
            }
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.Marca = product.Marca;
            existingProduct.Price = product.Price;
            _context.Entry(existingProduct).State = EntityState.Modified;

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


        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] CreateProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newProduct = new Product
            {
                Name = product.Name,
                Marca = product.Marca,
                Price = product.Price
            };
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return Created($"/api/Product/{newProduct.Id}", new { message = "producto creado", product = newProduct });
        }




        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
