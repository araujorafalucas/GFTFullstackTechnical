using GFTTechnicalTest.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GFTTechnicalTest.Domain.Entities
{
    [Table("OrderItems")]
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }        
        public int OrderId { get; set; }
        public Order Order { get; set; }        
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int AmountOrdered { get; set; }

        public string GetDishDescription()
        {
            return  Dish.Description + (AmountOrdered > 1 ? $"(x{AmountOrdered})": string.Empty);
        }

    }
}
