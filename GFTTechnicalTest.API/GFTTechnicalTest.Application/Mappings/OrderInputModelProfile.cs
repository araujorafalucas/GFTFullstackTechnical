using AutoMapper;
using GFTTechnicalTest.Application.Models;
using GFTTechnicalTest.Domain.Commands;

namespace GFTTechnicalTest.Application.Mappings
{
    public class OrderInputModelProfile : Profile
    {
        public OrderInputModelProfile()
        {
            CreateMap<OrderInputModel, RegisterNewOrderCommand>()
                .ConstructUsing(x => new RegisterNewOrderCommand(x.OrderInput));
        }       
    }
}
