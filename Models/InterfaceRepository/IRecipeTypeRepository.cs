using API_APENKOOI.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APENKOOI.Models.InterfaceRepository
{
    public interface IRecipeTypeRepository
    {
        Task<List<RecipeType>> GetAll();
    }
}
