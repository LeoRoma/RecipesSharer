using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesSharer.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RecipesSharer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        private readonly IConfiguration _config;
        private readonly RecipesSharerDbContext _context;

        public ImageController(RecipesSharerDbContext context, IConfiguration config)
        {
            _config = config;
            _context = context;
        }

        [Authorize]
        [HttpPost("post/{recipeId}")]
        public async Task<Guid> PostImage(IFormFile image, int recipeId)
        {

            using (var ms = new MemoryStream())
            {
                image.CopyTo(ms);
                var img = new Image()
                {
                    Suffix = Path.GetExtension(image.FileName),
                    Data = ms.ToArray()
                };

                img.RecipeId = recipeId;
                _context.Images.Add(img);
                await _context.SaveChangesAsync();
                return img.Id;
            }
        }

        
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Image>> DeleteImage(int id)
        {
            var image = await _context.Images.FirstOrDefaultAsync(i => i.RecipeId == id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return image;
        }

    }
}
