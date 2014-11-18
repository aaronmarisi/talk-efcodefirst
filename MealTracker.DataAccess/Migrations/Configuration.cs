namespace MealTracker.DataAccess.Migrations
{
    using MealTracker.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<MealTracker.DataAccess.MealContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "MealTracker.DataAccess.MealContext";
        }

        protected override void Seed(MealTracker.DataAccess.MealContext context)
        {
            if (context.Meals.Count() == 0)
            {
                // 2014-11-12
                context.Meals.Add(new Meal { Id = 1, Type = "Breakfast", DateAndTime = new DateTime(2014, 11, 12, 6, 0, 0) });
                context.Meals.Add(new Meal { Id = 2, Type = "Lunch", DateAndTime = new DateTime(2014, 11, 12, 12, 0, 0) });
                context.Meals.Add(new Meal { Id = 3, Type = "Dinner", DateAndTime = new DateTime(2014, 11, 12, 17, 30, 0) });
                context.Meals.Add(new Meal { Id = 4, Type = "Snack", DateAndTime = new DateTime(2014, 11, 12, 15, 0, 0) });

                // 2014-11-11
                context.Meals.Add(new Meal { Id = 5, Type = "Breakfast", DateAndTime = new DateTime(2014, 11, 11, 6, 0, 0) });
                context.Meals.Add(new Meal { Id = 6, Type = "Lunch", DateAndTime = new DateTime(2014, 11, 11, 12, 0, 0) });
                context.Meals.Add(new Meal { Id = 7, Type = "Dinner", DateAndTime = new DateTime(2014, 11, 11, 17, 30, 0) });
                context.Meals.Add(new Meal { Id = 8, Type = "Snack", DateAndTime = new DateTime(2014, 11, 11, 15, 0, 0) });

                // 2014-11-10
                context.Meals.Add(new Meal { Id = 9, Type = "Breakfast", DateAndTime = new DateTime(2014, 11, 10, 6, 0, 0) });
                context.Meals.Add(new Meal { Id = 10, Type = "Lunch", DateAndTime = new DateTime(2014, 11, 10, 12, 0, 0) });
                context.Meals.Add(new Meal { Id = 11, Type = "Dinner", DateAndTime = new DateTime(2014, 11, 10, 17, 30, 0) });
                context.Meals.Add(new Meal { Id = 12, Type = "Snack", DateAndTime = new DateTime(2014, 11, 10, 15, 0, 0) });

                // 2014-11-09
                context.Meals.Add(new Meal { Id = 13, Type = "Breakfast", DateAndTime = new DateTime(2014, 11, 9, 6, 0, 0) });
                context.Meals.Add(new Meal { Id = 14, Type = "Lunch", DateAndTime = new DateTime(2014, 11, 9, 12, 0, 0) });
                context.Meals.Add(new Meal { Id = 15, Type = "Dinner", DateAndTime = new DateTime(2014, 11, 9, 17, 30, 0) });
                context.Meals.Add(new Meal { Id = 16, Type = "Snack", DateAndTime = new DateTime(2014, 11, 9, 15, 0, 0) });

                // 2014-11-08
                context.Meals.Add(new Meal { Id = 17, Type = "Breakfast", DateAndTime = new DateTime(2014, 11, 8, 6, 0, 0) });
                context.Meals.Add(new Meal { Id = 18, Type = "Lunch", DateAndTime = new DateTime(2014, 11, 8, 12, 0, 0) });
                context.Meals.Add(new Meal { Id = 19, Type = "Dinner", DateAndTime = new DateTime(2014, 11, 8, 17, 30, 0) });
                context.Meals.Add(new Meal { Id = 20, Type = "Snack", DateAndTime = new DateTime(2014, 11, 8, 15, 0, 0) });


                var foodCount = context.Food.Count();
                if (foodCount != 0)
                {
                    for (int i = foodCount - 1; i >= 0; i--)
                    {
                        var food = context.Food.ElementAt(i);
                        context.Food.Remove(food);
                    }
                }

                int foodId = 1;

                // 2014-11-12 -------------------------------------------------------------------------------------------
                // Meal 1 Breakfast
                context.Food.Add(new Food { Id = foodId++, MealId = 1, Name = "Eggs", Quantity = "3", Calories = 300 });
                context.Food.Add(new Food { Id = foodId++, MealId = 1, Name = "Bacon", Quantity = "2 Slices", Calories = 200 });

                // Meal 2 Lunch
                context.Food.Add(new Food { Id = foodId++, MealId = 2, Name = "Ham Sandwhich", Quantity = "1", Calories = 400 });
                context.Food.Add(new Food { Id = foodId++, MealId = 2, Name = "Coke", Quantity = "1 can", Calories = 125 });

                // Meal 3 Dinner
                context.Food.Add(new Food { Id = foodId++, MealId = 3, Name = "Pepperoni Pizza", Quantity = "2 Slices", Calories = 520 });
                context.Food.Add(new Food { Id = foodId++, MealId = 3, Name = "Coke", Quantity = "1 Can", Calories = 125 });

                // Meal 4 Snack 
                context.Food.Add(new Food { Id = foodId++, MealId = 4, Name = "Cookie", Quantity = "1", Calories = 250 });

                // 2014-11-11 --------------------------------------------------------------------------------------------
                // Meal 5 Breakfast
                context.Food.Add(new Food { Id = foodId++, MealId = 5, Name = "Smoothie", Quantity = "1", Calories = 300 });

                // Meal 6 Lunch
                context.Food.Add(new Food { Id = foodId++, MealId = 6, Name = "Chicken Soup", Quantity = "1 Bowl", Calories = 350 });
                context.Food.Add(new Food { Id = foodId++, MealId = 6, Name = "Salad w/ dressing", Quantity = "1", Calories = 250 });

                // Meal 7 Dinner
                context.Food.Add(new Food { Id = foodId++, MealId = 7, Name = "Hamburger", Quantity = "1", Calories = 520 });
                context.Food.Add(new Food { Id = foodId++, MealId = 7, Name = "French Fries", Quantity = "1 Medium", Calories = 450 });

                // Meal 8 Snack 
                context.Food.Add(new Food { Id = foodId++, MealId = 8, Name = "Carrots", Quantity = "3", Calories = 120 });

                // 2014-11-10 -----------------------------------------------------------------------------------
                // Meal 9 Breakfast
                context.Food.Add(new Food { Id = foodId++, MealId = 9, Name = "Smoothie", Quantity = "1", Calories = 300 });

                // Meal 10 Lunch
                context.Food.Add(new Food { Id = foodId++, MealId = 10, Name = "Chicken Soup", Quantity = "1 Bowl", Calories = 350 });
                context.Food.Add(new Food { Id = foodId++, MealId = 10, Name = "Salad w/ dressing", Quantity = "1", Calories = 250 });

                // Meal 11 Dinner
                context.Food.Add(new Food { Id = foodId++, MealId = 11, Name = "Steak", Quantity = "8 oz", Calories = 450 });
                context.Food.Add(new Food { Id = foodId++, MealId = 11, Name = "Mashed Potatoes", Quantity = "1 cup", Calories = 400 });
                context.Food.Add(new Food { Id = foodId++, MealId = 11, Name = "Green Beans", Quantity = "1/2 cup", Calories = 100 });

                // Meal 12 Snack
                context.Food.Add(new Food { Id = foodId++, MealId = 12, Name = "Carrots", Quantity = "3", Calories = 120 });

                // 2014-11-09 --------------------------------------------------------------------------------------------
                // Meal 13 Breakfast
                context.Food.Add(new Food { Id = foodId++, MealId = 13, Name = "Eggs", Quantity = "3", Calories = 300 });
                context.Food.Add(new Food { Id = foodId++, MealId = 13, Name = "Bacon", Quantity = "2 Slices", Calories = 200 });

                // Meal 14 Lunch
                context.Food.Add(new Food { Id = foodId++, MealId = 14, Name = "Ham Sandwhich", Quantity = "1", Calories = 400 });
                context.Food.Add(new Food { Id = foodId++, MealId = 14, Name = "Coke", Quantity = "1 can", Calories = 125 });

                // Meal 15 Dinner
                context.Food.Add(new Food { Id = foodId++, MealId = 15, Name = "Italian Hoagie", Quantity = "1 large", Calories = 600 });
                context.Food.Add(new Food { Id = foodId++, MealId = 15, Name = "Coke", Quantity = "1 Can", Calories = 125 });
                context.Food.Add(new Food { Id = foodId++, MealId = 15, Name = "Potato Chips", Quantity = "1 small bag", Calories = 200 });

                // Meal 16 Snack
                context.Food.Add(new Food { Id = foodId++, MealId = 16, Name = "Cookie", Quantity = "1", Calories = 250 });

                // 2014-11-08 -----------------------------------------------------------------------------------
                // Meal 17 Breakfast
                context.Food.Add(new Food { Id = foodId++, MealId = 17, Name = "Smoothie", Quantity = "1", Calories = 300 });

                // Meal 18 Lunch
                context.Food.Add(new Food { Id = foodId++, MealId = 18, Name = "Chinese Food", Quantity = "A lot", Calories = 900 });

                // Meal 19 Dinner
                context.Food.Add(new Food { Id = foodId++, MealId = 19, Name = "Hamburger", Quantity = "1", Calories = 520 });
                context.Food.Add(new Food { Id = foodId++, MealId = 19, Name = "French Fries", Quantity = "1 Medium", Calories = 450 });

                // Meal 20 Snack
                context.Food.Add(new Food { Id = foodId++, MealId = 20, Name = "Carrots", Quantity = "3", Calories = 120 });
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
