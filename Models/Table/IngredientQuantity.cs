
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_APENKOOI.Models
{
    public class IngredientQuantity
    {
        public int id { get; set; }
        public int IngredientId { get; set; }
        [ForeignKey("IngredientId")]
        public virtual Ingredient Ingredient { get; set; }
        public string Amount { get; set; }
        public int QuantityTypeId { get; set; }
        [ForeignKey("QuantityTypeId")]
        public virtual QuantityType QuantityType { get; set; }
        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        [JsonIgnoreAttribute]
        public virtual Recipe Recipe { get; set; }
    }
}
