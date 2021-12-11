using GFTTechnicalTest.Domain.Entities;
using GFTTechnicalTest.Domain.Repositories;
using GFTTechnicalTest.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFTTechnicalTest.Infrastructure.Data.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly GFTTechnicalTestContext GFTTechnicalTestContext;

        public DishRepository(GFTTechnicalTestContext gftTechnicalTestContext)
        {
            GFTTechnicalTestContext = gftTechnicalTestContext;
        }

        public async Task AddAsync(Dish dish)
        {
            await GFTTechnicalTestContext.AddAsync(dish);
        }

        public async Task<IEnumerable<Dish>> GetAllAsync()
        {
            return await GFTTechnicalTestContext.Dishes.ToListAsync();
        }

        public async Task<Dish> GetByTypeAndMealTimeAsync(int dishType, string mealTime)
        {
            return await GFTTechnicalTestContext
                         .Dishes
                         .AsNoTracking()
                         .Where(x => x.DishType == dishType && x.MealTime == mealTime)
                         .FirstOrDefaultAsync();
        }
    }
}
