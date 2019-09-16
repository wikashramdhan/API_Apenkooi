using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APENKOOI.Models
{
    public interface IRecipeRepository
    {
        Recipe Get(int id);
        Task<IEnumerable<Recipe>> GetAll();
        Recipe Add(Recipe content);
        Recipe Update(Recipe contentChanges);
        Recipe Delete(int id);
    }
}
