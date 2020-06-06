using API_APENKOOI.Models.InterfaceRepository;
using API_APENKOOI.Models.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APENKOOI.Models.Repository
{
    public class RecipeTypeRepository : IRecipeTypeRepository
    {
        private readonly Context _context;

        public RecipeTypeRepository(Context context)
        {
            _context = context;
        }
        public async Task <List<RecipeType>> GetAll()
        {
            var recipeType = await _context.RecipeType.ToListAsync();

            return recipeType;
        }
    }
}
