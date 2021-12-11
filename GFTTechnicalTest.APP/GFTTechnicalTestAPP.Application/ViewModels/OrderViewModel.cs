using GFTTechnicalTestAPP.Domain.Entities;
using System.Collections.Generic;

namespace GFTTechnicalTestAPP.Application.ViewModels
{
    public class OrderViewModel
    {
        public OrderRequestModel Order = new OrderRequestModel();
        public IEnumerable<OrderRequestModel> Orders { get; set; }
    }
}
