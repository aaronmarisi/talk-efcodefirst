using MealTracker.Models.Dto;
using MealTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MealTracker.Services.Converters;

namespace MealTracker.Services
{
    public interface IMealToMealDtoConverter
    {
        MealDto Convert(Meal meal);
    }
    public class MealToMealDtoConverter: IMealToMealDtoConverter
    {
        private readonly IFoodToFoodDtoConverter _foodToFoodDtoConverter;
        
        public MealToMealDtoConverter(IFoodToFoodDtoConverter foodToFoodDtoConverter)
        {
            _foodToFoodDtoConverter = foodToFoodDtoConverter;
        }
        public MealDto Convert(Meal meal)
        {
            return new MealDto
            {
                Id = meal.Id,
                Type = meal.Type,
                Date = meal.DateAndTime.ToString("yyy-MM-dd"),
                Time = meal.DateAndTime.ToString("HH:mm"),
                FoodDtos = meal.Foods.Select(f => _foodToFoodDtoConverter.Convert(f)).ToList()
            };
        }
    }
}
