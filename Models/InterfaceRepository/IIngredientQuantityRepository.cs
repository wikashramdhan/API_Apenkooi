using API_APENKOOI.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APENKOOI.Models.InterfaceRepository
{
    interface IIngredientQuantityRepository
    {
        IngredientQuantity Get(int id);
        List<IngredientQuantity> GetAll();
        IngredientQuantity Add(IngredientQuantity content);
        IngredientQuantity Update(IngredientQuantity contentChanges);
        IngredientQuantity Delete(int id);

    }
}
