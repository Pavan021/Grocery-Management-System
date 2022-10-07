using GroceryStoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreManagement.Core
{
    public interface IUser
    {
        Task<List<UserModel>> GetAllUsersAsync();

        Task<UserModel> GetUsersByIdAsync(int id);
        Task<UserModel> Create(UserModel model);

        Task update(UserModel model);
        Task delete(int id);
    }
}
