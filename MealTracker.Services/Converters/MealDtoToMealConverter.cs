using MealTracker.Models;
using MealTracker.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTracker.Services.Converters
{
    public interface IMealDtoToMealConverter
    {
        Meal Convert(MealDto mealDto);
    }

    public class MealDtoToMealConverter : IMealDtoToMealConverter
    {
        private IFoodDtoToFoodConverter _foodDtoToFoodConverter;

        public MealDtoToMealConverter(IFoodDtoToFoodConverter foodDtoToFoodConverter)
        {
            _foodDtoToFoodConverter = foodDtoToFoodConverter;
        }
        public Meal Convert(MealDto mealDto)
        {
            var meal = new Meal();

            meal.Id = mealDto.Id;
            meal.Type = mealDto.Type;
            meal.DateAndTime = DateTime.Parse(mealDto.Date + " " + mealDto.Time);
            meal.Foods = mealDto.FoodDtos.Select(dto => 
                {
                    var food = _foodDtoToFoodConverter.Convert(dto);
                    food.MealId = meal.Id;

                    return food;
                }).ToList();            

            return meal;
        }
    }
}
