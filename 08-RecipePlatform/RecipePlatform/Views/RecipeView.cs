using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlatform.Models;

namespace RecipePlatform.Views
{
    public class RecipeView
    {
        public int ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== PLATAFORMA DE RECETAS =====");
            Console.WriteLine("1. Ver todas las recetas");
            Console.WriteLine("2. Buscar receta por nombre");
            Console.WriteLine("3. Filtrar por tipo de comida");
            Console.WriteLine("4. Filtrar por ingrediente");
            Console.WriteLine("5. Ver detalle de una receta");
            Console.WriteLine("6. Guardar receta en mis favoritas");
            Console.WriteLine("7. Ver mis recetas guardadas");
            Console.WriteLine("8. Compartir una receta");
            Console.WriteLine("0. Salir");
            Console.WriteLine("Digite una opción: ");
            return int.Parse(Console.ReadLine());
        }

        public string ReadText(string label)
        {
            Console.WriteLine(label);
            return Console.ReadLine();
        }

        public int ReadNumber(string label)
        {
            Console.WriteLine(label);
            return int.Parse(Console.ReadLine());
        }

        public void ShowMealTypes(string[] mealTypes)
        {
            for (int i = 0; i < mealTypes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {mealTypes[i]}");
            }
        }

        public void ShowRecipes(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No se encontraron recetas.");
                return;
            }

            foreach (Recipe recipe in recipes)
            {
                string saved = "";

                if (recipe.IsSaved())
                {
                    saved = " [Guardada]";
                }

                Console.WriteLine($"#{recipe.GetId()} - {recipe.GetName()} ({recipe.GetMealType()}) - por {recipe.GetAuthor()}{saved}");
            }
        }

        public void ShowRecipeDetail(Recipe recipe)
        {
            Console.WriteLine();
            Console.WriteLine($"===== {recipe.GetName()} =====");
            Console.WriteLine($"Tipo de comida: {recipe.GetMealType()}");
            Console.WriteLine($"Compartida por: {recipe.GetAuthor()}");
            Console.WriteLine($"Ingredientes: {recipe.GetIngredients()}");
            Console.WriteLine($"Preparación: {recipe.GetPreparation()}");
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
