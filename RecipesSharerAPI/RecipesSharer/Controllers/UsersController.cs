using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RecipesSharer.Models;

namespace RecipesSharer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly RecipesSharerDbContext _context;
        private Helper _helper = new Helper();
        

        public UsersController(RecipesSharerDbContext context, IConfiguration config)
        {
            _config = config;
            _context = context;
        }

        // GET: /Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: /Users/1/recipes
        [HttpGet("{id}/recipes")]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetUserRecipes(int id)
        {
            return await _context.Recipes.Where(r => r.UserId == id).Include(x => x.User).Include(r => r.Image).ToListAsync();
        }

        //GET: /Users/1/recipes/1
        [HttpGet("{userId}/recipe/{recipeId}")]
        public async Task<ActionResult<Recipe>> GetUserRecipe(int userId, int recipeId)
        {
            return await _context.Recipes.Where(x => x.UserId == userId && x.RecipeId == recipeId)
                .Include(r => r.Ingredients)
                .Include(r => r.Equipments)
                .Include(r => r.Steps)
                .FirstOrDefaultAsync(r => r.RecipeId == recipeId);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            
            var checkUser = _context.Users.Where(u => u.Email == user.Email).FirstOrDefault();
            if (checkUser != null)
            {
                return BadRequest();
            }
            
            user.Password = _helper.EncryptPlainTextToCipherText(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
