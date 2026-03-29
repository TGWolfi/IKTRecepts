using RecipeProject;
using System;

class Program
{
    static void Main()
    {
        RecipeManager manager = new RecipeManager();
        manager.LoadCSV("data/recipes.csv");

        while (true)
        {
            Console.WriteLine("\n1 - Hozzáadás");
            Console.WriteLine("2 - Lista");
            Console.WriteLine("3 - Keresés");
            Console.WriteLine("4 - Szűrés");
            Console.WriteLine("5 - Mentés");
            Console.WriteLine("6 - HTML");
            Console.WriteLine("0 - Kilépés");

            string val = Console.ReadLine();

            if (val == "1")
            {
                Console.Write("Név: ");
                string name = Console.ReadLine();

                Console.Write("Kategória: ");
                string cat = Console.ReadLine();

                manager.AddRecipe(new Recipe(
                    manager.recipes.Count + 1,
                    name,
                    cat,
                    "Leírás",
                    30,
                    5,
                    false
                ));
            }
            else if (val == "2")
            {
                manager.ListRecipes();
            }
            else if (val == "3")
            {
                Console.Write("Keresés: ");
                manager.Search(Console.ReadLine());
            }
            else if (val == "4")
            {
                Console.Write("Kategória: ");
                manager.Filter(Console.ReadLine());
            }
            else if (val == "5")
            {
                manager.SaveCSV("data/recipes.csv");
            }
            else if (val == "6")
            {
                HtmlGenerator.GenerateAll(manager.recipes);
                Console.WriteLine("HTML kész!");
            }
            else if (val == "0")
            {
                break;
            }
        }
    }
}