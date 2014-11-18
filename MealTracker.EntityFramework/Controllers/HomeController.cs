using MealTracker.Models.Dto;
using MealTracker.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MealTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        private IMealService _mealService;
        
        public HomeController(IMealService mealService)
        {
            _mealService = mealService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return Redirect("~/history");
        }

        public ActionResult Meal(int id = -1)
        {
            MealDto mealDto;
            if (id >= 0)
                mealDto = _mealService.GetMealDto(id);
            else
                mealDto = _mealService.GetEmptyMealDto();

            return View(mealDto);
        }

        public ActionResult History()
        {
            var dailySummaries = _mealService.GetDailySummaries();
            return View(dailySummaries);
        }

        [HttpPost]
        [ActionName("save-meal")]
        public ActionResult SaveMealApi(MealDto mealInput)
        {
            _mealService.SaveMeal(mealInput);
            return Json(new { message = "yes" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("delete-meal")]
        public ActionResult DeleteMealApi(int mealId = default(int))
        {            
            DateTime date = DateTime.Parse(_mealService.GetMealDto(mealId).Date);            
            _mealService.DeleteMeal(mealId);
            
            DailyMealSummaryDto summary = _mealService.GetDailySummary(date);

            return Json(new { calories = summary.Calories, mealsAmt = summary.Meals.Count() }, JsonRequestBehavior.AllowGet);
        }
    }
}