using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTracker.Models.Dto
{
    public class DailyMealSummaryDto
    {
        public DateTime Day { get; set; }
        public IEnumerable<MealDto> Meals { get; set; }
        public int Calories { get; set; }
    }
}
