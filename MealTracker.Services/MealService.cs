using MealTracker.Models;
using MealTracker.Models.Dto;
using MealTracker.Repositories;
using MealTracker.Services.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTracker.Services
{
    public interface IMealService
    {
        void SaveMeal(MealDto mealInput);

        MealDto GetMealDto(int id);

        MealDto GetEmptyMealDto();

        IEnumerable<DailyMealSummaryDto> GetDailySummaries();

        void DeleteMeal(int mealId);

        DailyMealSummaryDto GetDailySummary(DateTime date);
    }

    public class MealService : IMealService
    {
        private readonly IMealDtoToMealConverter _mealInputToMealConverter;
        private readonly IMealTrackingUnitOfWork _mealTrackingUnitOfWork;
        private readonly IMealToMealDtoConverter _mealToMealDtoConverter;

        public MealService(IMealDtoToMealConverter mealInputToMealConverter, IMealToMealDtoConverter mealToMealDtoConverter, IMealTrackingUnitOfWork mealTrackingUnitOfWork)
        {
            _mealInputToMealConverter = mealInputToMealConverter;
            _mealTrackingUnitOfWork = mealTrackingUnitOfWork;
            _mealToMealDtoConverter = mealToMealDtoConverter;
        }

        public void SaveMeal(MealDto dto)
        {
            var mealInput = _mealInputToMealConverter.Convert(dto);            
            _mealTrackingUnitOfWork.Meals.InsertOrUpdate(mealInput);

            var existingMeal = _mealTrackingUnitOfWork.Meals.All.FirstOrDefault(m => m.Id == mealInput.Id);
            if (existingMeal != null)
            {
                // Add or Update all of the foods in the new meal
                foreach (var food in mealInput.Foods)
                {
                    _mealTrackingUnitOfWork.Food.InsertOrUpdate(food);
                }

                // Delete any foods that existed previously but are no longer included
                for (int i = existingMeal.Foods.Count -1; i >= 0; i--)
                {
                    var food = existingMeal.Foods[i];

                    if (mealInput.Foods.All(input => input.Id != food.Id))
                        _mealTrackingUnitOfWork.Food.Delete(food.Id);
                }
            }

            _mealTrackingUnitOfWork.Save();
        }

        public MealDto GetMealDto(int id)
        {
            var meal = _mealTrackingUnitOfWork.Meals.All.FirstOrDefault(m => m.Id == id);
            return _mealToMealDtoConverter.Convert(meal);
        }

        public MealDto GetEmptyMealDto()
        {
            return new MealDto
            {
                Id = default(int),
                Type = "",
                Date = "",
                Time = "",
                FoodDtos = new List<FoodDto>()
            };
        }

        public IEnumerable<DailyMealSummaryDto> GetDailySummaries()
        {
            var dateTimes = _mealTrackingUnitOfWork.Meals.All.Select(m => m.DateAndTime).ToList();
            var dates = dateTimes.Select(d => d.Date).Distinct().ToList();

            var summaries = dates.Select(date => GetDailySummary(date)).OrderByDescending(s => s.Day);

            return summaries;
        }

        public void DeleteMeal(int mealId)
        {
            _mealTrackingUnitOfWork.Meals.Delete(mealId);
            _mealTrackingUnitOfWork.Save();
        }

        public DailyMealSummaryDto GetDailySummary(DateTime date)
        {
            var summary = new DailyMealSummaryDto();

            summary.Day = date.Date;
            summary.Meals = _mealTrackingUnitOfWork.Meals.All.Where(meal =>
                    meal.DateAndTime.Year == date.Year
                    && meal.DateAndTime.Month == date.Month
                    && meal.DateAndTime.Day == date.Day).ToList().Select(meal => _mealToMealDtoConverter.Convert(meal)).OrderBy(meal => meal.Type);
            summary.Calories = summary.Meals.SelectMany(m => m.FoodDtos).Sum(f => f.Calories);
            
            return summary;
        }
    }
}
