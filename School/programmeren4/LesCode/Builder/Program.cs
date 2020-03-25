using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new MealBuilder();
            var burgerMeal = builder.PrepareBurgerMeal(); 
            Console.WriteLine("BurgerMeal: ");
            burgerMeal.ShowItems();
            Console.WriteLine("Costs: {0}", burgerMeal.GetCosts().ToString("C"));

            var chickenMeal = builder.PrepareChickenMeal();
            Console.WriteLine("ChickenMeal: ");
            chickenMeal.ShowItems();
            Console.WriteLine("Costs: {0}", chickenMeal.GetCosts().ToString("C"));

            Console.ReadLine();
        }
    }
}
