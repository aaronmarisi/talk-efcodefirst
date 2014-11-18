using MealTracker.DataAccess.Mapping;
using MealTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTracker.DataAccess
{
    public class MealContext: DbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Food> Food { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FoodMapping());
            modelBuilder.Configurations.Add(new MealMapping());
        }
    }
}
