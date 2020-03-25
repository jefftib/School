using System;
using System.Collections.Generic;
using System.Text;
using Builder.Models;

namespace Builder
{
    class MealBuilder
    {
     public  Meal  PrepareChickenMeal()
        {
            var meal = new Meal();
            meal.AddItem(new Water());
            meal.AddItem(new ChickenBurger());
            return meal;
        }

      public Meal  PrepareBurgerMeal()
        {
            var meal = new Meal();
            meal.AddItem(new Hamburger());
            meal.AddItem(new Cola());
            return meal;
        }

    }
}
