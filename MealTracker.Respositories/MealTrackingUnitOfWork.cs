using MealTracker.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTracker.Repositories
{
    public interface IMealTrackingUnitOfWork : IUnitOfWork 
    {
        IMealRepository Meals { get; }
        IFoodRepository Food { get; }
    }

    public class MealTrackingUnitOfWork : IMealTrackingUnitOfWork
    {
        //private readonly List<IRepository> _repositories = new List<IRepository>();
        private readonly MealContext _mealContext;

        public MealTrackingUnitOfWork(MealContext mealContext)
        {
            _mealContext = mealContext;
            //Meals = meals;
            //Food = food;
            Meals = new MealRepository(mealContext);
            Food = new FoodRepository(mealContext);
        }

        public IMealRepository Meals { get; set; }
        public IFoodRepository Food { get; set; }

        public void Save()
        {
            _mealContext.SaveChanges();
        }

        public void Dispose()
        {
            Meals.Dispose();
            Food.Dispose();
        }
    }
}
