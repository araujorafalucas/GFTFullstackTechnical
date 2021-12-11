using GFTTechnicalTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GFTTechnicalTest.Infrastructure.Data.Context
{
    public class GFTTechnicalTestContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public GFTTechnicalTestContext(DbContextOptions<GFTTechnicalTestContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    AllowMultipleOrders = false,
                    Description = "eggs",
                    DishId = 1,
                    DishType = 1,
                    MealTime = "morning"
                },
                new Dish
                {
                    AllowMultipleOrders = false,
                    Description = "toast",
                    DishId = 2,
                    DishType = 2,
                    MealTime = "morning"
                },
                new Dish
                {
                    AllowMultipleOrders = true,
                    Description = "coffee",
                    DishId = 3,
                    DishType = 3,
                    MealTime = "morning"
                },
                new Dish
                {
                    AllowMultipleOrders = false,
                    Description = "steak",
                    DishId = 4,
                    DishType = 1,
                    MealTime = "night"
                },
                new Dish
                {
                    AllowMultipleOrders = true,
                    Description = "potato",
                    DishId = 5,
                    DishType = 2,
                    MealTime = "night"
                },
                new Dish
                {
                    AllowMultipleOrders = false,
                    Description = "wine",
                    DishId = 6,
                    DishType = 3,
                    MealTime = "night"
                },
                new Dish
                {
                    AllowMultipleOrders = false,
                    Description = "cake",
                    DishId = 7,
                    DishType = 4,
                    MealTime = "night"
                }
            );
        }

    }
}
