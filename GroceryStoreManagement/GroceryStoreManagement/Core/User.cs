using GroceryStoreManagement.Common;
using GroceryStoreManagement.DataAccess;
using GroceryStoreManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreManagement.Core
{
    public class User : IUser
    {
        public readonly GroceryDbContext _context;

        public User(GroceryDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            try
            {
                var Users = await _context.UserModel.ToListAsync();
                if (Users == null)
                {
                    throw new EmptyItemsException("No Users Found");
                }
                return Users;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<UserModel> GetUsersByIdAsync(int id)
        {
            try
            {
                var Users = await _context.UserModel.FindAsync(id);
                if (Users == null)
                {
                    throw new EmptyItemsException("No Users found in given Id");
                }
                return Users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserModel> Create(UserModel model)
        {
            try
            {
                _context.UserModel.Add(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task update(UserModel model)
        {
            try
            {
                _context.Entry(model).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task delete(int id)
        {
            try
            {
                var UsersTodelete = await _context.UserModel.FindAsync(id);

                if (UsersTodelete == null)
                {
                    throw new EmptyItemsException("There's no id present in List");
                }
                _context.UserModel.Remove(UsersTodelete);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}
