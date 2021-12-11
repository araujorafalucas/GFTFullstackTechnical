using GFTTechnicalTestAPP.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFTTechnicalTestAPP.Infrastructure.ExternalServices.Interfaces
{
    public class OrderExternalService : IOrderExternalService
    {
        private readonly IConfiguration Configuration;
        public OrderExternalService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<IEnumerable<OrderRequestModel>> GetOrdersAsync()
        {
            var transfersApiService = RestService.For<IOrderExternalService>(Configuration["ApiAddress"]);

            return await transfersApiService.GetOrdersAsync();

        }

        public async Task<OrderRequestModel> AddOrderAsync(OrderRequestModel orderRequestModel)
        {
            var transfersApiService = RestService.For<IOrderExternalService>(Configuration["ApiAddress"]);

            return await transfersApiService.AddOrderAsync(orderRequestModel);
        }
    }
}
