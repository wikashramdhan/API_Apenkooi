using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_APENKOOI.Models.Table
{
    public class Recipe
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public int? HowManyPersons { get; set; }
        public int? TimeCreated { get; set; }
        public virtual ICollection<IngredientQuantity> IngredientQuantities { get; set;}
        public int RecipeTypeId { get; set; }
        public virtual RecipeType RecipeType { get; set; }
        public string PreparationMethods { get; set; }
                
    }
}
