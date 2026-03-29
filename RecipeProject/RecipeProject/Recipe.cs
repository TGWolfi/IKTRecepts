using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject
{
    class Recipe
{
    public int Id;
    public string Name;
    public string Category;
    public string Description;
    public int Time;
    public int Rating;
    public bool IsFavorite;

    public Recipe(int id, string name, string cat, string desc, int time, int rating, bool fav)
    {
        Id = id;
        Name = name;
        Category = cat;
        Description = desc;
        Time = time;
        Rating = rating;
        IsFavorite = fav;
    }
}
}
