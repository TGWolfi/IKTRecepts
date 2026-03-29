using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class RecipeManager
    {
        public List<Recipe> recipes = new List<Recipe>();

        public void AddRecipe(Recipe r)
        {
            recipes.Add(r);
        }

        public void ListRecipes()
        {
            foreach (Recipe r in recipes)
            {
                Console.WriteLine(r.Id + " - " + r.Name + " (" + r.Category + ")");
            }
        }

        public void Search(string text)
        {
            foreach (Recipe r in recipes)
            {
                if (r.Name.ToLower().Contains(text.ToLower()))
                {
                    Console.WriteLine(r.Name);
                }
            }
        }

        public void Filter(string category)
        {
            foreach (Recipe r in recipes)
            {
                if (r.Category.ToLower() == category.ToLower())
                {
                    Console.WriteLine(r.Name);
                }
            }
        }

        public void SaveCSV(string path)
        {
            List<string> lines = new List<string>();

            foreach (Recipe r in recipes)
            {
                string line = r.Id + ";" + r.Name + ";" + r.Category + ";" + r.Description + ";" + r.Time + ";" + r.Rating + ";" + r.IsFavorite;
                lines.Add(line);
            }

            File.WriteAllLines(path, lines);
        }

        public void LoadCSV(string path)
        {
            if (!File.Exists(path)) return;

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] p = line.Split(';');

                Recipe r = new Recipe(
                    int.Parse(p[0]),
                    p[1],
                    p[2],
                    p[3],
                    int.Parse(p[4]),
                    int.Parse(p[5]),
                    bool.Parse(p[6])
                );

                recipes.Add(r);
            }
        }
    }
}
