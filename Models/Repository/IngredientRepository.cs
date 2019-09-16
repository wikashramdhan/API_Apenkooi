using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APENKOOI.Models
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly Context context;
        public IngredientRepository(Context context)
        {
            this.context = context;
        }
        public Ingredient Add(Ingredient conent)
        {
            context.Ingredient.Add(conent);
            context.SaveChanges();
            return conent;
        }

        public Ingredient Delete(int id)
        {
            Ingredient conent = context.Ingredient.Find(id);
            if (conent != null)
            {
                context.Ingredient.Remove(conent);
                context.SaveChanges();
            }
            return conent;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return context.Ingredient;
        }


        public Ingredient Get(int id)
        {
            return context.Ingredient.Find(id);
        }

        public Ingredient Update(Ingredient contentChanges)
        {
            var Ingredient = context.Ingredient.Attach(contentChanges);
            Ingredient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return contentChanges;
        }
    }
}
