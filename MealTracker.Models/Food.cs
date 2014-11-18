
namespace MealTracker.Models
{
    public class Food
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public int Calories { get; set; }
    }
}
