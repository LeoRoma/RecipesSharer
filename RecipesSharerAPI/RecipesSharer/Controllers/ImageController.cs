using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesSharer.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace RecipesSharer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        [Authorize]
        [HttpPost("post/{recipeId}")]
        public async Task<Guid> Image(IFormFile image, int recipeId)
        {
            using (var db = new RecipesSharerDbContext())
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
                    db.Images.Add(img);
                    await db.SaveChangesAsync();
                    return img.Id;
                }
            }
        }
    }
}
