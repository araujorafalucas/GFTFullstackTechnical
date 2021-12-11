using AutoMapper;
using GFTTechnicalTest.Application.Models;
using GFTTechnicalTest.Domain.Entities;

namespace GFTTechnicalTest.Application.Mappings
{
    public class OrderResponseModelProfile : Profile
    {
        public OrderResponseModelProfile()
        {
            CreateMap<Order, OrderResponseModel>()
                .ForMember(response => response.OrderInput, options =>
                {
                  options.MapFrom(order => order.OrderInput);
                })
                .ForMember(response => response.OrderOutput, options =>
                 {
                     options.MapFrom(order => order.GetOutputText());
                 });
        }       
    }
}
