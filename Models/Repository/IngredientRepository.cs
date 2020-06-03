using API_APENKOOI.Models.InterfaceRepository;
using API_APENKOOI.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APENKOOI.Models.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly Context _context;
        public IngredientRepository(Context context)
        {
            _context = context;
        }
        public Ingredient Add(Ingredient conent)
        {
            _context.Ingredient.Add(conent);
            _context.SaveChanges();
            return conent;
        }

        public Ingredient Delete(int id)
        {
            Ingredient conent = _context.Ingredient.Find(id);
            if (conent != null)
            {
                _context.Ingredient.Remove(conent);
                _context.SaveChanges();
            }
            return conent;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _context.Ingredient;
        }


        public Ingredient Get(int id)
        {
            return _context.Ingredient.Find(id);
        }

        public Ingredient Update(Ingredient contentChanges)
        {
            var Ingredient = _context.Ingredient.Attach(contentChanges);
            Ingredient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return contentChanges;
        }
    }
}
