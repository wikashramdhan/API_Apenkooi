using API_APENKOOI.Models.InterfaceRepository;
using API_APENKOOI.Models.Table;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APENKOOI.Models.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly Context _context;
        public RecipeRepository(Context context)
        {
            this._context = context;
        }
        public Recipe Add(Recipe recipe)
        {
            _context.Recipe.Add(recipe);
            _context.SaveChanges();
            return recipe;
        }

        public Recipe Delete(int id)
        {
            Recipe conent = _context.Recipe.Find(id);
            if (conent != null)
            {
                _context.Recipe.Remove(conent);
                _context.SaveChanges();
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

                var recipe = await _context.Recipe.ToListAsync();

                return recipe;
            }
            catch(Exception ex)
            {
                return null;
            }
        }


        public Recipe Get(int id)
        {
            //Recipe r = context.Recipe.Find(id);
            //r.RecipeType = context.RecipeType.Find(r.RecipeTypeId);
            Recipe recipe = _context.Recipe.Include(r => r.RecipeType)
                                   .Include(r => r.IngredientQuantities)
                                   .ThenInclude(i => i.Ingredient)
                                   .Include(r => r.IngredientQuantities)
                                   .ThenInclude(i => i.QuantityType)
                                   .FirstOrDefault(re => re.Id == id);

            
            return recipe;
        }

        public Recipe Update(Recipe contentChanges)
        {
            var recipe = _context.Recipe.Attach(contentChanges);
            recipe.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return contentChanges;
        }
    }
}
