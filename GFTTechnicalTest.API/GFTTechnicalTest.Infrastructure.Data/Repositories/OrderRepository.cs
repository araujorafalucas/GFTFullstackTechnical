using GFTTechnicalTest.Domain.Entities;
using GFTTechnicalTest.Domain.Repositories;
using GFTTechnicalTest.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GFTTechnicalTest.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GFTTechnicalTestContext GFTTechnicalTestContext;
        
        public OrderRepository(GFTTechnicalTestContext gftTechnicalTestContext)
        {
            GFTTechnicalTestContext = gftTechnicalTestContext;            
        }

        public async Task AddAsync(Order order)
        {
            foreach(var item in order.OrderItems)
            {                
                GFTTechnicalTestContext.Entry(item.Dish).State = EntityState.Unchanged;                
            }

            await GFTTechnicalTestContext.AddAsync(order);
            await GFTTechnicalTestContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {

            var orders = await GFTTechnicalTestContext.Orders.Include(x => x.OrderItems)
                                                                  .ThenInclude(x => x.Dish).ToListAsync();

            return orders;
            
        }
    }
}
