using GroceryStoreManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreManagement.DataAccess
{
    public class GroceryDbContext: DbContext
    {
        public GroceryDbContext(DbContextOptions<GroceryDbContext> options) : base(options)
        {

        }
        public DbSet<GroceryModel> GroceryModel { get; set; }
        public DbSet<OrderModel> OrderModel { get; set; }
        public DbSet<CartModel> CartModel { get; set; }
        public DbSet<UserModel> UserModel { get; set; }

    }
}
