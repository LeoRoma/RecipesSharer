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
    public class StepsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly RecipesSharerDbContext _context;

        public StepsController(RecipesSharerDbContext context, IConfiguration config)
        {
            _config = config;
            _context = context;
        }
    }
}
