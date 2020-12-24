using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesSharer.Models
{
    public class Recipe
    {
        public Recipe()
        {
            Ingredients = new HashSet<Ingredient>();
            Steps = new HashSet<Step>();
            Equipments = new HashSet<Equipment>();
        }

        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public string PreparationTime { get; set; }
        public string CookingTime { get; set; }
        public string AdditionalTime { get; set; }
        public int Servings { get; set; }
        
        public DateTime PostDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Step> Steps { get; set; }
        public ICollection<Equipment> Equipments { get; set; }
        public Image Image { get; set; }
    }
}
