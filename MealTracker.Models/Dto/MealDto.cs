using System.Collections.Generic;

namespace MealTracker.Models.Dto
{
    public class MealDto
    {
        public MealDto ()
        {
            FoodDtos = new List<FoodDto>();
        }
        public int Id { get; set; }
        public string Type { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public IList<FoodDto> FoodDtos { get; set; }
    }
}
