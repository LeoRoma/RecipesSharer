using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesSharer.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string Amount { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
