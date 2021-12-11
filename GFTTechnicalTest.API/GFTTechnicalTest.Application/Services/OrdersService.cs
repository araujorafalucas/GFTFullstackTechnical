using AutoMapper;
using GFTTechnicalTest.Application.Interfaces;
using GFTTechnicalTest.Application.Models;
using GFTTechnicalTest.Domain.Commands;
using GFTTechnicalTest.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFTTechnicalTest.Application.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IMapper Mapper;
        private readonly IMediator Mediator;
        private readonly IOrderRepository OrderRepository;

        public OrdersService(IMapper mapper, IMediator mediator, IOrderRepository orderRepository)
        {
            Mapper = mapper;
            Mediator = mediator;
            OrderRepository = orderRepository;
        }

        public async Task<OrderResponseModel> AddOrderAsync(OrderInputModel inputOrder)
        {
            var registerCommand = Mapper.Map<RegisterNewOrderCommand>(inputOrder);
            
            return  Mapper.Map<OrderResponseModel>(await Mediator.Send(registerCommand));
        }

        public async Task<IEnumerable<OrderResponseModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<OrderResponseModel>>(await OrderRepository.GetAllAsync());
        }
    }
}
