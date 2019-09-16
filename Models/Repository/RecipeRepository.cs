using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APENKOOI.Models
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly Context context;
        public RecipeRepository(Context context)
        {
            this.context = context;
        }
        public Recipe Add(Recipe conent)
        {
            context.Recipe.Add(conent);
            context.SaveChanges();
            return conent;
        }

        public Recipe Delete(int id)
        {
            Recipe conent = context.Recipe.Find(id);
            if (conent != null)
            {
                context.Recipe.Remove(conent);
                context.SaveChanges();
            }
            return conent;
        }

        //public IEnumerable<Recipe> GetAll()
        //{
        //    return context.Recipe;
        //}

        public async Task<IEnumerable<Recipe>> GetAll()
        {
            try
            {
                //var recipe = await context.Recipe
                //    .Include(r => r.RecipeType)
                //    .Include(r => r.IngredientQuantities)
                //        .ThenInclude(iq => iq.Ingredient)
                //    .Include(r => r.IngredientQuantities)
                //        .ThenInclude(iq=> iq.QuantityType)
                //    .ToListAsync();

                var recipe = await context.Recipe.ToListAsync();

                return recipe;
            }
            catch(Exception ex)
            {
                return null;
            }
        }


        public Recipe Get(int id)
        {
            return context.Recipe.Find(id);
        }

        public Recipe Update(Recipe contentChanges)
        {
            var recipe = context.Recipe.Attach(contentChanges);
            recipe.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return contentChanges;
        }
    }
}
