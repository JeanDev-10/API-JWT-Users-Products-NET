using API_JWT_USERS_PRODUCTS.Context;
using API_JWT_USERS_PRODUCTS.Models;
using API_JWT_USERS_PRODUCTS.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims; // Añade esta línea
namespace API_JWT_USERS_PRODUCTS.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApiJwtProductsUsersContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductController(ApiJwtProductsUsersContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        // Obtener el ID del usuario logueado
        private int GetCurrentUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            return int.Parse(userIdClaim.Value);
        }



        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var userId = GetCurrentUserId();
            var products = await _context.Products.Where(p => p.UserId == userId).ToListAsync();
            return Ok(new { message = "Lista de productos", data = products });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneProducts(int id)
        {
            var userId = GetCurrentUserId();
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);
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
            var userId = GetCurrentUserId();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != product.Id)
            {
                return BadRequest();
            }
            var existingProduct = await _context.Products.FirstOrDefaultAsync(product => product.Id == id && product.UserId == userId);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.Marca = product.Marca;
            existingProduct.Price = product.Price;
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
            var userId = GetCurrentUserId();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newProduct = new Product
            {
                Name = product.Name,
                Marca = product.Marca,
                Price = product.Price,
                UserId = userId // Asignar el ID del usuario logueado
            };
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return Created($"/api/Product/{newProduct.Id}", new { message = "producto creado", product = newProduct });
        }




        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var userId = GetCurrentUserId();
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

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
