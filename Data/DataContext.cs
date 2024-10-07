using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FastFoodAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().HasData(
                new Food { Id = 1, Name = "Hamburguer", Price = 14, Description = "A delicious hamburguer!", Type = FoodTypes.Burguer }
            );
        }

        public DbSet<Food> Foods => Set<Food>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Order> Orders => Set<Order>();
    }
}