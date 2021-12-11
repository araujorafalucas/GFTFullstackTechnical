using GFTTechnicalTestAPP.Domain.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTTechnicalTestAPP.Infrastructure.ExternalServices.Interfaces
{
    public interface IOrderExternalService
    {
        [Get("/api/orders")]
        Task<IEnumerable<OrderRequestModel>> GetOrdersAsync();

        [Post("/api/orders")]
        Task<OrderRequestModel> AddOrderAsync(OrderRequestModel orderRequestModel);
    }
}
