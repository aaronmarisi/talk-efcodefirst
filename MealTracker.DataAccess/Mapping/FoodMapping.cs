using MealTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTracker.DataAccess.Mapping
{
    public class FoodMapping: EntityTypeConfiguration<Food>
    {
        public FoodMapping()
        {
            this.Property(f => f.Name).IsRequired();
        }
    }
}
