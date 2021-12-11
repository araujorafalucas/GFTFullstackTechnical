using GFTTechnicalTestAPP.Application.ViewModels;
using GFTTechnicalTestAPP.Domain.Entities;
using System.Threading.Tasks;

namespace GFTTechnicalTestAPP.Application.Interfaces
{
    public interface IOrdersService
    {
        Task<OrderRequestModel> AddOrderAsync(string input);
        Task<OrderViewModel> GetOrdersAsync();
    }
}
