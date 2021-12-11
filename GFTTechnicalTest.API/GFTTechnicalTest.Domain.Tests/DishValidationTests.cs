using FluentAssertions;
using GFTTechnicalTest.Domain.Entities;
using Xunit;

namespace GFTTechnicalTest.Domain.Tests
{
    public class DishValidationTests
    {
        [Theory]
        [InlineData(false, 1, true, 1 )]
        [InlineData(true, 3, true, 3)]
        [InlineData(false, 4, false, 1)]        
        public void ValidateRequesteAmountShouldReturnExpectedResult(bool allowMultipleOrders, 
                                                                     int requestedAmount, 
                                                                     bool dishOrderIsValid,
                                                                     int amountAllowed)
        {
            var dish = new Dish()
            {
                AllowMultipleOrders = allowMultipleOrders                
            };

            var validation = dish.ValidateRequestedAmount(requestedAmount);

            validation.amountAllowed.Should().Be(amountAllowed);

            validation.isValid.Should().Be(dishOrderIsValid);
        }
    }
}
