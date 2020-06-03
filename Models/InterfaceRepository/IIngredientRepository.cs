using API_APENKOOI.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APENKOOI.Models.InterfaceRepository
{
    public interface IIngredientRepository
    {
        Ingredient Get(int id);
        IEnumerable<Ingredient> GetAll();
        Ingredient Add(Ingredient content);
        Ingredient Update(Ingredient contentChanges);
        Ingredient Delete(int id);
    }
}
