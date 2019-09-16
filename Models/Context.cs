using API_APENKOOI.Models.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APENKOOI.Models
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Recipe> Recipe { get; private set; }
        public DbSet<Ingredient> Ingredient { get; private set; }
        public DbSet<RecipeType> RecipeType { get; private set; }
        public DbSet<IngredientQuantity> IngredientQuantity { get; private set;}
        public DbSet<QuantityType> QuantityType { get; private set; }
        public DbSet<APIUsers> APIUsers { get; private set; }

    }

    
}
