using GFTTechnicalTest.Domain.Commands;
using GFTTechnicalTest.Domain.Entities;
using GFTTechnicalTest.Domain.Repositories;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GFTTechnicalTest.Domain.Handlers
{
    public class RegisterNewOrderCommandHandler : IRequestHandler<RegisterNewOrderCommand, Order>
    {
        private readonly IOrderRepository OrderRepository;
        private readonly IDishRepository DishRepository;

        public RegisterNewOrderCommandHandler(IOrderRepository orderRepository, IDishRepository dishRepository)
        {
            OrderRepository = orderRepository;
            DishRepository = dishRepository;
        }

        public async Task<Order> Handle(RegisterNewOrderCommand registerNewOrderCommand, CancellationToken cancellationToken)
        {
            var inputs = registerNewOrderCommand.Input.Split(",");
            var mealTime = inputs.FirstOrDefault();
            var order = new Order(registerNewOrderCommand.Input, mealTime);

            var inputsSummarizeds = inputs.Skip(1).GroupBy(input => input)
                           .Select(result => new
                           {
                               dishType = result.Key,
                               requestedAmount = result.Count()
                           })
                           .OrderBy(x => x.dishType);

            foreach (var input in inputsSummarizeds)
            {
                var dish = await DishRepository.GetByTypeAndMealTimeAsync(Convert.ToInt32(input.dishType), mealTime);

                if (dish == null)
                {
                    order.SetErrorState();
                    break;
                }

                var amountValidation = dish.ValidateRequestedAmount(input.requestedAmount);

                order.CreateAndAddItem(dish, amountValidation.amountAllowed);
                
                if (!amountValidation.isValid)
                {
                    order.SetErrorState();
                    break;
                }
            }

            await OrderRepository.AddAsync(order);

            return order;

        }
    }
}
