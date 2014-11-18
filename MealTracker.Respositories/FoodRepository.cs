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
    public interface IFoodRepository : IRepository<Food> { }
    
    public class FoodRepository : IFoodRepository
    {
        private readonly MealContext _mealContext;

        public FoodRepository(MealContext mealContext)
        {
            _mealContext = mealContext;
        }

        public IQueryable<Food> All
        {
            get 
            { 
                return _mealContext.Food; 
            }
        }

        public void InsertOrUpdate(Food newFood)
        {
            var existingFood = All.FirstOrDefault(f => f.Id == newFood.Id);

            if (existingFood == null)
            {
                _mealContext.Food.Add(newFood);
            }
            else
            {
                existingFood.Calories = newFood.Calories;
                existingFood.Name = newFood.Name;
                existingFood.Quantity = newFood.Quantity;

                _mealContext.Entry(existingFood).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var food = _mealContext.Food.FirstOrDefault(m => m.Id == id);
            _mealContext.Food.Remove(food);
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
