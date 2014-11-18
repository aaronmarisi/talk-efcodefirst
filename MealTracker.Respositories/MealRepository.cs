using MealTracker.DataAccess;
using MealTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTracker.Repositories
{
    public interface IMealRepository : IRepository<Meal> { }
    
    public class MealRepository : IMealRepository
    {
        private readonly MealContext _mealContext;

        public MealRepository(MealContext mealContext)
        {
            _mealContext = mealContext;
        }

        public IQueryable<Meal> All
        {
            get 
            { 
                return _mealContext.Meals; 
            }
        }

        public void InsertOrUpdate(Meal newMeal)
        {
            var existingMeal = All.FirstOrDefault(m => m.Id == newMeal.Id);

            if (existingMeal == null)
            {
                _mealContext.Meals.Add(newMeal);
            }
            else
            {
                existingMeal.DateAndTime = newMeal.DateAndTime;
                existingMeal.Type = newMeal.Type;

                _mealContext.Entry(existingMeal).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var meal = _mealContext.Meals.FirstOrDefault(m => m.Id == id);
            _mealContext.Meals.Remove(meal);
        }

        public void Save()
        {
            _mealContext.SaveChanges();
        }

        public void Dispose()
        {
            _mealContext.Dispose();
        }
    }
}
