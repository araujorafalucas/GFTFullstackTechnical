using GFTTechnicalTest.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFTTechnicalTest.Application.Interfaces
{
    public interface IOrdersService
    {
        public Task<OrderResponseModel> AddOrderAsync(OrderInputModel inputOrder);

        public Task<IEnumerable<OrderResponseModel>> GetAllAsync();
             
    }
}
