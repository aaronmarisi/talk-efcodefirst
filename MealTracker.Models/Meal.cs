using System;
using System.Collections.Generic;

namespace MealTracker.Models
{
    public class Meal
    {
        public Meal()
        {
            Foods = new List<Food>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime DateAndTime { get; set; }
        public virtual IList<Food> Foods { get; set; }
    }
}
