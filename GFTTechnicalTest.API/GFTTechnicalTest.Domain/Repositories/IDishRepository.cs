using GFTTechnicalTest.Domain.Entities;
using GFTTechnicalTest.Domain.Repositories.Base;
using System.Threading.Tasks;

namespace GFTTechnicalTest.Domain.Repositories
{
    public interface IDishRepository : IBaseRepository<Dish>
    {
        public Task<Dish> GetByTypeAndMealTimeAsync(int dishType, string mealTime);
    }
}
