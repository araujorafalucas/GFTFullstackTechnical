using GFTTechnicalTestAPP.Application.Interfaces;
using GFTTechnicalTestAPP.Application.ViewModels;
using GFTTechnicalTestAPP.Domain.Entities;
using GFTTechnicalTestAPP.Infrastructure.ExternalServices.Interfaces;
using System.Threading.Tasks;

namespace GFTTechnicalTestAPP.Application.Services
{
    public class OrdersService : IOrdersService
    {
        IOrderExternalService OrderExternalService;
        
        public OrdersService(IOrderExternalService orderExternalService)
        {
            OrderExternalService = orderExternalService;
        }

        public async Task<OrderRequestModel> AddOrderAsync(string input)
        {
            return await OrderExternalService.AddOrderAsync(new OrderRequestModel() { OrderInput = input });

        }

        public async Task<OrderViewModel> GetOrdersAsync()
        {
            return new OrderViewModel()
            {
                Orders = await OrderExternalService.GetOrdersAsync()
            };
        }
    }
}
