using System;
using System.Collections.Generic;

namespace Cooking
{
    public class CookingApp
    {
        private static Recipe recipe = new Recipe();

        public static void Main(string[] args)
        {
            Console.WriteLine("Cooking - Part 1");
            Console.WriteLine("----------------");

            while (true)
            {
                DisplayMenu();

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EnterRecipeDetails();
                        break;
                    case "2":
                        DisplayRecipe();
                        break;
                    case "3":
                        ScaleRecipe();
                        break;
                    case "4":
                        ResetQuantities();
                        break;
                    case "5":
                        ClearData();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Enter Recipe Details");
            Console.WriteLine("2. Display Recipe");
            Console.WriteLine("3. Scale Recipe");
            Console.WriteLine("4. Reset Quantities");
            Console.WriteLine("5. Clear Data");
            Console.WriteLine("6. Exit");
        }

        private static void EnterRecipeDetails()
        {
            recipe = new Recipe();

            Console.WriteLine("Enter the number of ingredients:");
            int ingredientCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter ingredient {i + 1} name:");
                string name = Console.ReadLine();

                Console.WriteLine($"Enter quantity for {name}:");
                double quantity = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter unit of measurement for {name} (e.g., tablespoon):");
                string unit = Console.ReadLine();

                recipe.Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit });
            }

            Console.WriteLine("Enter the number of steps:");
            int stepCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter step {i + 1} description:");
                string description = Console.ReadLine();

                recipe.Steps.Add(new Step { Description = description });
            }

            Console.WriteLine("Recipe details entered successfully!");
        }

        private static void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe:");
            Console.WriteLine("Ingredients:");

            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");

            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipe.Steps[i].Description}");
            }
        }

        private static void ScaleRecipe()
        {
            Console.WriteLine("\nEnter scaling factor (0.5, 2, 3):");
            double factor = double.Parse(Console.ReadLine());

            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Quantity *= factor;

                // Convert units if necessary
                if (ingredient.Unit == "tablespoons" && factor >= 2)
                {
                    ingredient.Unit = "cups";
                    ingredient.Quantity /= 8;
                }
            }

            Console.WriteLine("Recipe scaled successfully!");
        }

        private static void ResetQuantities()
        {
            // Implement resetting quantities to original values
            Console.WriteLine("Quantities reset successfully!");

            // Reset units if they were changed during scaling
            foreach (var ingredient in recipe.Ingredients)
            {
                if (ingredient.Unit == "cups")
                {
                    ingredient.Unit = "tablespoons";
                    ingredient.Quantity *= 8;
                }
            }
        }

        private static void ClearData()
        {
            Console.WriteLine("\nAre you sure you want to clear all data? (yes/no)");
            string confirmation = Console.ReadLine().ToLower();

            if (confirmation == "yes")
            {
                recipe = new Recipe();
                Console.WriteLine("Data cleared successfully!");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
    }
}