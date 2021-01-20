using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RecipesSharer.Models
{
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [IgnoreDataMember]
        public byte[] Data { get; set; }
        public string Suffix { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
