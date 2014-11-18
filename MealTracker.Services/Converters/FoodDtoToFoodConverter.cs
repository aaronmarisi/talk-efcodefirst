using MealTracker.Models;
using MealTracker.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTracker.Services.Converters
{
    public interface IFoodDtoToFoodConverter
    {
        Food Convert(FoodDto food);
    }

    public class FoodDtoToFoodConverter : IFoodDtoToFoodConverter
    {
        public Food Convert(FoodDto dto)
        {
            return new Food
            {
                Id = dto.Id,
                //MealId = dto.MealId,
                Name = dto.Name,
                Quantity = dto.Quantity,
                Calories = dto.Calories
            };
        }
    }
}
