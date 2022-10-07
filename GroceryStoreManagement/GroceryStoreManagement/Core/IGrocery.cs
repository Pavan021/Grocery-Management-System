using GroceryStoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreManagement.Core
{
   public interface IGrocery
    {
        Task<List<GroceryModel>> GetAllGroceryAsync();

        Task<GroceryModel> GetGroceryByIdAsync(int id);
        Task<GroceryModel> Create(GroceryModel model);

        Task update(GroceryModel model);
        Task delete(int id);
    }
}
