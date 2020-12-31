using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RecipesSharer.Models;
using Microsoft.EntityFrameworkCore;

namespace RecipesSharer.Middleware
{
    public class DynamicImageProvider
    {
        private readonly RequestDelegate next;
        public IServiceProvider service;
        private string pathCondition = "/dynamic/images/";

        public DynamicImageProvider(RequestDelegate next)
        {
            this.next = next;
        }

        private static readonly string[] suffixes = new string[] {
            ".png",
            ".jpg",
            ".gif",
            ".jpeg"
        };

        private bool IsImagePath(PathString path)
        {
            if (path == null || !path.HasValue)
                return false;

            return suffixes.Any
                   (x => path.Value.EndsWith(x, StringComparison.OrdinalIgnoreCase));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var path = context.Request.Path;
                if (IsImagePath(path) && path.Value.Contains(pathCondition))
                {
                    byte[] buffer = null;
                    var id = Guid.Parse(Path.GetFileName(path).Split(".")[0]);

                    using (var db = new RecipesSharerDbContext())
                    {
                        var imageFromDb =
                           await db.Images.SingleOrDefaultAsync(x => x.Id == id);
                        buffer = imageFromDb.Data;
                    }

                    if (buffer != null && buffer.Length > 1)
                    {
                        context.Response.ContentLength = buffer.Length;
                        context.Response.ContentType = "image/" +
                                            Path.GetExtension(path).Replace(".", "");
                        await context.Response.Body.WriteAsync(buffer, 0, buffer.Length);
                    }
                    else
                        context.Response.StatusCode = 404;
                }
            }
            finally
            {
                if (!context.Response.HasStarted)
                    await next(context);
            }
        }
    }
}
