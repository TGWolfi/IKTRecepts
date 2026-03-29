using RecipeProject;
using System.Collections.Generic;
using System.IO;

class HtmlGenerator
{
    public static void GenerateAll(List<Recipe> recipes)
    {
        Directory.CreateDirectory("output");

        File.Copy("template/style.css", "output/style.css", true);

        GenerateItems(recipes);
        GenerateIndex(recipes);
        GenerateFavorites(recipes);
    }

    static void GenerateItems(List<Recipe> recipes)
    {
        string template = File.ReadAllText("template/template.html");

        string rows = "";

        foreach (Recipe r in recipes)
        {
            rows += "<tr>";
            rows += "<td>" + r.Id + "</td>";
            rows += "<td>" + r.Name + "</td>";
            rows += "<td><span class='badge badge-category'>" + r.Category + "</span></td>";
            rows += "<td>" + r.Description + "</td>";
            rows += "<td>⭐ " + r.Rating + "</td>";
            rows += "<td>" + r.Time + " perc</td>";

            if (r.IsFavorite)
                rows += "<td>❤️</td>";
            else
                rows += "<td></td>";

            rows += "</tr>";
        }

        string table = "<div class='table-container'><table><thead><tr>";
        table += "<th>#</th><th>Név</th><th>Kategória</th><th>Leírás</th><th>Értékelés</th><th>Idő</th><th>Kedvenc</th>";
        table += "</tr></thead><tbody>";
        table += rows;
        table += "</tbody></table></div>";

        string result = template;
        result = result.Replace("{{TITLE}}", "Összes recept");
        result = result.Replace("{{DESCRIPTION}}", "Teljes lista");
        result = result.Replace("{{ITEMS}}", table);
        result = result.Replace("{{STATS}}", "");

        File.WriteAllText("output/items.html", result);
    }


    static void GenerateIndex(List<Recipe> recipes)
    {
        string template = File.ReadAllText("template/template.html");

        string items = "";
        int count = 0;

        foreach (Recipe r in recipes)
        {
            if (count >= 4) break;

            items += MakeCard(r);
            count++;
        }

        string result = template;
        result = result.Replace("{{TITLE}}", "Recept Gyűjtemény");
        result = result.Replace("{{DESCRIPTION}}", "Kiemelt receptek");
        result = result.Replace("{{ITEMS}}", items);
        result = result.Replace("{{STATS}}", "");

        File.WriteAllText("output/index.html", result);
    }
    static void GenerateFavorites(List<Recipe> recipes)
    {
        string template = File.ReadAllText("template/template.html");

        string items = "";

        foreach (Recipe r in recipes)
        {
            if (r.IsFavorite)
            {
                items += MakeCard(r);
            }
        }

        string result = template;
        result = result.Replace("{{TITLE}}", "Kedvencek");
        result = result.Replace("{{DESCRIPTION}}", "Kedvenc receptek");
        result = result.Replace("{{ITEMS}}", items);
        result = result.Replace("{{STATS}}", "");

        File.WriteAllText("output/favorites.html", result);
    }

    static string MakeCard(Recipe r)
    {
        string card = "<article class='recipe-card'>";

        card += "<div class='favorite-badge " + (r.IsFavorite ? "active" : "inactive") + "'>❤️</div>";

        card += "<div class='recipe-card-body'>";
        card += "<span class='badge badge-category'>" + r.Category + "</span>";
        card += "<h3>" + r.Name + "</h3>";
        card += "<p class='recipe-desc'>" + r.Description + "</p>";

        card += "<div class='recipe-meta'>";
        card += "<span>" + r.Time + " perc</span>";
        card += "<span>⭐ " + r.Rating + "</span>";
        card += "</div>";

        card += "</div>";
        card += "</article>";

        return card;
    }
}