using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesSharer.Models
{
    public class User
    {
        public User()
        {
            Recipes = new HashSet<Recipe>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
