using FluentAssertions;
using GFTTechnicalTest.Domain.Commands;
using GFTTechnicalTest.Domain.Entities;
using GFTTechnicalTest.Domain.Handlers;
using GFTTechnicalTest.Domain.Repositories;
using NSubstitute;
using System;
using System.Linq;
using Xunit;

namespace GFTTechnicalTest.Domain.Tests
{
    public class RegisterNewOrderCommandHandlerTests
    {
        const string MORNING_MEALTIME = "morning";
        const string NIGHT_MEALTIME = "night";

        private void MockMorningDishes(IDishRepository dishRepository)
        {

            dishRepository.GetByTypeAndMealTimeAsync(1, MORNING_MEALTIME).Returns(new Dish()
            {
                AllowMultipleOrders = false,
                Description = "eggs",
                DishId = 1,
                DishType = 1,
                MealTime = MORNING_MEALTIME
            });

            dishRepository.GetByTypeAndMealTimeAsync(2, MORNING_MEALTIME).Returns(new Dish()
            {
                AllowMultipleOrders = false,
                Description = "toast",
                DishId = 2,
                DishType = 2,
                MealTime = MORNING_MEALTIME
            });

            dishRepository.GetByTypeAndMealTimeAsync(3, MORNING_MEALTIME).Returns(new Dish()
            {
                AllowMultipleOrders = true,
                Description = "coffee",
                DishId = 3,
                DishType = 3,
                MealTime = MORNING_MEALTIME
            });

            dishRepository.GetByTypeAndMealTimeAsync(4, MORNING_MEALTIME).Returns((Dish)null);
        }

        private void MockNightDishes(IDishRepository dishRepository)
        {
            dishRepository.GetByTypeAndMealTimeAsync(1, NIGHT_MEALTIME).Returns(new Dish()
            {
                AllowMultipleOrders = false,
                Description = "steak",
                DishId = 4,
                DishType = 1,
                MealTime = NIGHT_MEALTIME
            });

            dishRepository.GetByTypeAndMealTimeAsync(2, NIGHT_MEALTIME).Returns(new Dish()
            {
                AllowMultipleOrders = true,
                Description = "potato",
                DishId = 5,
                DishType = 2,
                MealTime = NIGHT_MEALTIME
            });

            dishRepository.GetByTypeAndMealTimeAsync(3, NIGHT_MEALTIME).Returns(new Dish()
            {
                AllowMultipleOrders = false,
                Description = "wine",
                DishId = 6,
                DishType = 3,
                MealTime = NIGHT_MEALTIME
            });
            dishRepository.GetByTypeAndMealTimeAsync(4, NIGHT_MEALTIME).Returns(new Dish()
            {
                AllowMultipleOrders = false,
                Description = "cake",
                DishId = 7,
                DishType = 4,
                MealTime = NIGHT_MEALTIME
            });
        }

        [Theory]
        [InlineData("morning, 1, 2, 3", "eggs, toast, coffee")]
        public async void FirstCaseShouldCaseReturnValidOrder(string input, string expectedResponse)
        {
            //arrange
            var inputs = input.Split(",");
            var mealTime = inputs.FirstOrDefault();

            var orderRepository = Substitute.For<IOrderRepository>();
            var dishRepository = Substitute.For<IDishRepository>();

            MockMorningDishes(dishRepository);

            //act
            var registerNewOrderCommandHandler = new RegisterNewOrderCommandHandler(orderRepository, dishRepository);
            var order = await registerNewOrderCommandHandler.Handle(new RegisterNewOrderCommand(input), new System.Threading.CancellationToken());

            //assert
            order.Should()
                .BeOfType(typeof(Order))
                .And
                .NotBeNull()
                .And
                .Match<Order>(x => !x.HasError);

            order.GetOutputText().Should().Be(expectedResponse);

        }

        [Theory]
        [InlineData("morning, 2, 1, 3", "eggs, toast, coffee")]
        public async void SecondCaseShouldReturnValidOrder(string input, string expectedResponse)
        {
            //arrange

            var inputs = input.Split(",");
            var mealTime = inputs.FirstOrDefault();

            var orderRepository = Substitute.For<IOrderRepository>();
            var dishRepository = Substitute.For<IDishRepository>();

            MockMorningDishes(dishRepository);

            //act
            var registerNewOrderCommandHandler = new RegisterNewOrderCommandHandler(orderRepository, dishRepository);
            var order = await registerNewOrderCommandHandler.Handle(new RegisterNewOrderCommand(input), new System.Threading.CancellationToken());

            //assert
            order.Should()
                .BeOfType(typeof(Order))
                .And
                .NotBeNull()
                .And
                .Match<Order>(x => !x.HasError);

            order.GetOutputText().Should().Be(expectedResponse);

        }

        [Theory]
        [InlineData("morning, 1, 2, 3, 4", "eggs, toast, coffee, error")]
        public async void ThirdCaseShouldReturnInValidOrder(string input, string expectedResponse)
        {
            var inputs = input.Split(",");
            var mealTime = inputs.FirstOrDefault();

            //arrange
            var orderRepository = Substitute.For<IOrderRepository>();
            var dishRepository = Substitute.For<IDishRepository>();

            MockMorningDishes(dishRepository);

            //act
            var registerNewOrderCommandHandler = new RegisterNewOrderCommandHandler(orderRepository, dishRepository);
            var order = await registerNewOrderCommandHandler.Handle(new RegisterNewOrderCommand(input), new System.Threading.CancellationToken());

            //assert
            order.Should()
                .BeOfType(typeof(Order))
                .And
                .NotBeNull()
                .And
                .Match<Order>(x => x.HasError);

            order.GetOutputText().Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData("morning, 1, 2, 3, 3, 3", "eggs, toast, coffee(x3)")]
        public async void FourthCaseShouldReturnValidOrder(string input, string expectedResponse)
        {
            var inputs = input.Split(",");
            var mealTime = inputs.FirstOrDefault();

            //arrange
            var orderRepository = Substitute.For<IOrderRepository>();
            var dishRepository = Substitute.For<IDishRepository>();

            MockMorningDishes(dishRepository);

            //act
            var registerNewOrderCommandHandler = new RegisterNewOrderCommandHandler(orderRepository, dishRepository);
            var order = await registerNewOrderCommandHandler.Handle(new RegisterNewOrderCommand(input), new System.Threading.CancellationToken());

            //assert
            order.Should()
                .BeOfType(typeof(Order))
                .And
                .NotBeNull()
                .And
                .Match<Order>(x => !x.HasError);

            order.GetOutputText().Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData("night, 1, 2, 3, 4", "steak, potato, wine, cake")]
        public async void FifthCaseShouldReturnValidOrder(string input, string expectedResponse)
        {
            var inputs = input.Split(",");
            var mealTime = inputs.FirstOrDefault();

            //arrange
            var orderRepository = Substitute.For<IOrderRepository>();
            var dishRepository = Substitute.For<IDishRepository>();
            
            MockNightDishes(dishRepository);

            //act
            var registerNewOrderCommandHandler = new RegisterNewOrderCommandHandler(orderRepository, dishRepository);
            var order = await registerNewOrderCommandHandler.Handle(new RegisterNewOrderCommand(input), new System.Threading.CancellationToken());

            //assert
            order.Should()
                .BeOfType(typeof(Order))
                .And
                .NotBeNull()
                .And
                .Match<Order>(x => !x.HasError);

            order.GetOutputText().Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData("night, 1, 2, 2, 4", "steak, potato(x2), cake")]
        public async void SixthCaseShouldReturnValidOrder(string input, string expectedResponse)
        {
            var inputs = input.Split(",");
            var mealTime = inputs.FirstOrDefault();

            //arrange
            var orderRepository = Substitute.For<IOrderRepository>();
            var dishRepository = Substitute.For<IDishRepository>();

            MockNightDishes(dishRepository);

            //act
            var registerNewOrderCommandHandler = new RegisterNewOrderCommandHandler(orderRepository, dishRepository);
            var order = await registerNewOrderCommandHandler.Handle(new RegisterNewOrderCommand(input), new System.Threading.CancellationToken());

            //assert
            order.Should()
                .BeOfType(typeof(Order))
                .And
                .NotBeNull()
                .And
                .Match<Order>(x => !x.HasError);

            order.GetOutputText().Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData("night, 1, 2, 3, 5", "steak, potato, wine, error")]
        public async void SeventhCaseShouldReturnInValidOrder(string input, string expectedResponse)
        {
            var inputs = input.Split(",");
            var mealTime = inputs.FirstOrDefault();

            //arrange
            var orderRepository = Substitute.For<IOrderRepository>();
            var dishRepository = Substitute.For<IDishRepository>();

            MockNightDishes(dishRepository);

            //act
            var registerNewOrderCommandHandler = new RegisterNewOrderCommandHandler(orderRepository, dishRepository);
            var order = await registerNewOrderCommandHandler.Handle(new RegisterNewOrderCommand(input), new System.Threading.CancellationToken());

            //assert
            order.Should()
                .BeOfType(typeof(Order))
                .And
                .NotBeNull()
                .And
                .Match<Order>(x => x.HasError);

            order.GetOutputText().Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData("night, 1, 1, 2, 3, 5", "steak, error")]
        public async void EighthCaseShouldReturnInValidOrder(string input, string expectedResponse)
        {
            var inputs = input.Split(",");
            var mealTime = inputs.FirstOrDefault();

            //arrange
            var orderRepository = Substitute.For<IOrderRepository>();
            var dishRepository = Substitute.For<IDishRepository>();
            MockNightDishes(dishRepository);

            //act
            var registerNewOrderCommandHandler = new RegisterNewOrderCommandHandler(orderRepository, dishRepository);
            var order = await registerNewOrderCommandHandler.Handle(new RegisterNewOrderCommand(input), new System.Threading.CancellationToken());

            //assert
            order.Should()
                .BeOfType(typeof(Order))
                .And
                .NotBeNull()
                .And
                .Match<Order>(x => x.HasError);

            order.GetOutputText().Should().Be(expectedResponse);
        }
    }
}
