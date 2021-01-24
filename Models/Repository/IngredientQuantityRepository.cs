using API_APENKOOI.Models.InterfaceRepository;
using API_APENKOOI.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APENKOOI.Models.Repository
{
    public class IngredientQuantityRepository : IIngredientQuantityRepository
    {
        private readonly Context context;
        public IngredientQuantityRepository(Context context)
        {
            this.context = context;
        }
        public IngredientQuantity Add(IngredientQuantity conent)
        {
            context.IngredientQuantity.Add(conent);
            context.SaveChanges();
            return conent;
        }

        public IngredientQuantity Delete(int id)
        {
            IngredientQuantity conent = context.IngredientQuantity.Find(id);
            if (conent != null)
            {
                context.IngredientQuantity.Remove(conent);
                context.SaveChanges();
            }
            return conent;
        }

        public List<IngredientQuantity> GetAll()
        {
            var lstIngredientQuantities = new List<IngredientQuantity>();
            foreach (IngredientQuantity i in context.IngredientQuantity)
            {
                var ingredientQuantity = new IngredientQuantity();
                i.id = ingredientQuantity.id;
                i.Ingredient = Get(ingredientQuantity.id).Ingredient;
                i.Amount = ingredientQuantity.Amount;
                i.QuantityType = Get(ingredientQuantity.id).QuantityType;
                i.RecipeId = ingredientQuantity.RecipeId;
                lstIngredientQuantities.Add(ingredientQuantity);
            }
            return lstIngredientQuantities;
        }


        public IngredientQuantity Get(int id)
        {
            return context.IngredientQuantity.Find(id);
        }

        public IngredientQuantity Update(IngredientQuantity contentChanges)
        {
            var IngredientQuantity = context.IngredientQuantity.Attach(contentChanges);
            IngredientQuantity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return contentChanges;
        }
    }
}
