using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GFTTechnicalTest.Domain.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderInput { get; set; }
        public string MealTime { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public bool HasError { get; set; }

        public Order()
        {

        }

        public Order(string orderInput, string mealTime)
        {
            OrderInput = orderInput;
            MealTime = mealTime;
        }

        public void CreateAndAddItem(Dish dish, int amount)
        {
            OrderItems.Add(new()
            {
                AmountOrdered = amount,
                Dish = dish,
                DishId = dish.DishId,
                Order = this,
                OrderId = OrderId
            });
        }

        public List<OrderItem> GetItems()
        {
            return OrderItems;
        }

        public void SetErrorState()
        {
            HasError = true;
        }

        public string GetOutputText()
        {
            var output = $"{(string.Join(", ", OrderItems.Select(item => item.GetDishDescription())))}";

            if (HasError)
            {
                output += ", error";
            }

            return output;
        }
    }
}
