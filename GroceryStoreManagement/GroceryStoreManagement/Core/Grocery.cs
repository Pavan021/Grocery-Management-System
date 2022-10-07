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
    public class Grocery : IGrocery
    {
        public readonly GroceryDbContext _context;

        public Grocery(GroceryDbContext context)
        {
            _context = context;
        }
        public async Task<List<GroceryModel>> GetAllGroceryAsync()
        {
            try
            {
                var groceries = await _context.GroceryModel.ToListAsync();
                if (groceries == null)
                {
                    throw new EmptyItemsException("No groceries Found");
                }
                return groceries;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<GroceryModel> GetGroceryByIdAsync(int id)
        {
            try
            {
                var groceries = await _context.GroceryModel.FindAsync(id);
                if (groceries == null)
                {
                    throw new EmptyItemsException("No grocery found in given Id");
                }
                return groceries;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<GroceryModel> Create(GroceryModel model)
        {
            try
            {
                _context.GroceryModel.Add(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task update(GroceryModel model)
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
                var GroceryTodelete = await _context.GroceryModel.FindAsync(id);

                if (GroceryTodelete == null)
                {
                    throw new EmptyItemsException("There's no id present in List");
                }
                _context.GroceryModel.Remove(GroceryTodelete);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}
