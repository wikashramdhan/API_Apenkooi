using API_APENKOOI.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APENKOOI.Models.InterfaceRepository
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
