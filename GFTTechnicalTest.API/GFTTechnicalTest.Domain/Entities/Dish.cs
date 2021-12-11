using System.ComponentModel.DataAnnotations.Schema;

namespace GFTTechnicalTest.Domain.Entities
{
    [Table("Dishes")]
    public class Dish
    {
        public int DishId { get; set; }
        public string Description { get; init; }
        public int DishType { get; init; }
        public bool AllowMultipleOrders { get; init; }
        public string MealTime { get; init; }
        
        public Dish()
        {

        }

        public (bool isValid, int amountAllowed) ValidateRequestedAmount(int amount)
        {
            if(AllowMultipleOrders)
            {
                return (true, amount);
            }

            return (amount == 1, 1);
        }       
    }
}
