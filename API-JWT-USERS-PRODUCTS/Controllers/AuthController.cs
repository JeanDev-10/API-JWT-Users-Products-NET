using API_JWT_USERS_PRODUCTS.Context;
using API_JWT_USERS_PRODUCTS.Custom;
using API_JWT_USERS_PRODUCTS.Models;
using API_JWT_USERS_PRODUCTS.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_JWT_USERS_PRODUCTS.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApiJwtProductsUsersContext _context;
        private readonly Utils _utils;
        public AuthController(ApiJwtProductsUsersContext apiJwtProductsUsersContext, Utils utils)
        {
            _context = apiJwtProductsUsersContext;
            _utils = utils;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                });
            }
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = _utils.EncryptSHA256(userDto.Password)
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Usuario registrado", new { message="Usuario registrado", data=user});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                });
            }
            var user = await _context.Users
                .Where
                (u =>
                u.Email == userDto.Email &&
                u.Password == _utils.EncryptSHA256(userDto.Password)
                ).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound("Invalid email or password.");
            }
            return Ok(new { message = "User login successfully.", token = _utils.generateJWT(user) });
        }


    }
}
