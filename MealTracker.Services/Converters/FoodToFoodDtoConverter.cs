using MealTracker.Models;
using MealTracker.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTracker.Services.Converters
{
    public interface IFoodToFoodDtoConverter
    {
        FoodDto Convert(Food food);
    }
    public class FoodToFoodDtoConverter: IFoodToFoodDtoConverter
    {
        public FoodDto Convert(Food food)
        {
            return new FoodDto
            {
                Name = food.Name,
                Id = food.Id,
                Calories = food.Calories,
                Quantity = food.Quantity
            };
        }
    }
}
