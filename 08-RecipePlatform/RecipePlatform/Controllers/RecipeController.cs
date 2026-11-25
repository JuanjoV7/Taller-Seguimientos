using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlatform.Models;
using RecipePlatform.Views;

namespace RecipePlatform.Controllers
{
    public class RecipeController
    {
        private List<Recipe> _recipes;
        private string[] _mealTypes;
        private RecipeView _view;
        private int _nextId;

        public RecipeController()
        {
            _recipes = new List<Recipe>();
            _mealTypes = new string[] { "Desayuno", "Almuerzo", "Cena", "Postre", "Bebida" };
            _view = new RecipeView();
            _nextId = 1;

            LoadInitialRecipes();
        }

        public void Run()
        {
            int option = -1;

            while (option != 0)
            {
                option = _view.ShowMenu();

                switch (option)
                {
                    case 1:
                        _view.ShowRecipes(_recipes);
                        break;
                    case 2:
                        SearchByName();
                        break;
                    case 3:
                        FilterByMealType();
                        break;
                    case 4:
                        FilterByIngredient();
                        break;
                    case 5:
                        ShowRecipeDetail();
                        break;
                    case 6:
                        SaveRecipe();
                        break;
                    case 7:
                        ShowSavedRecipes();
                        break;
                    case 8:
                        ShareRecipe();
                        break;
                    case 0:
                        _view.ShowMessage("Hasta luego.");
                        break;
                    default:
                        _view.ShowMessage("Opción no válida.");
                        break;
                }
            }
        }

        private void LoadInitialRecipes()
        {
            AddRecipe("Arepa con huevo", "Desayuno", "arepa, huevo, mantequilla, sal", "Asar la arepa, freír el huevo y servirlo sobre la arepa.", "Plataforma");
            AddRecipe("Arroz con pollo", "Almuerzo", "arroz, pollo, zanahoria, arveja, cebolla, ajo", "Cocinar el pollo, desmecharlo y mezclarlo con el arroz y las verduras.", "Plataforma");
            AddRecipe("Sopa de verduras", "Cena", "papa, zanahoria, ahuyama, cebolla, cilantro, sal", "Picar las verduras y cocinarlas en agua con sal hasta que estén blandas.", "Plataforma");
            AddRecipe("Ensalada de frutas", "Postre", "banano, fresa, mango, papaya, crema de leche, queso", "Picar las frutas, agregar la crema de leche y el queso rallado por encima.", "Plataforma");
            AddRecipe("Limonada de coco", "Bebida", "limón, leche de coco, azúcar, hielo", "Licuar el jugo de limón con la leche de coco, el azúcar y el hielo.", "Plataforma");
        }

        private void AddRecipe(string name, string mealType, string ingredients, string preparation, string author)
        {
            Recipe recipe = new Recipe(_nextId, name, mealType, ingredients, preparation, author);
            _recipes.Add(recipe);
            _nextId++;
        }

        private void SearchByName()
        {
            string text = _view.ReadText("Digite el nombre de la receta: ");
            List<Recipe> results = new List<Recipe>();

            foreach (Recipe recipe in _recipes)
            {
                if (recipe.NameContains(text))
                {
                    results.Add(recipe);
                }
            }

            _view.ShowRecipes(results);
        }

        private void FilterByMealType()
        {
            _view.ShowMealTypes(_mealTypes);
            int mealTypeOption = _view.ReadNumber("Seleccione el tipo de comida: ");

            if (mealTypeOption < 1 || mealTypeOption > _mealTypes.Length)
            {
                _view.ShowMessage("Tipo de comida no válido.");
                return;
            }

            string mealType = _mealTypes[mealTypeOption - 1];
            List<Recipe> results = new List<Recipe>();

            foreach (Recipe recipe in _recipes)
            {
                if (recipe.GetMealType() == mealType)
                {
                    results.Add(recipe);
                }
            }

            _view.ShowRecipes(results);
        }

        private void FilterByIngredient()
        {
            string ingredient = _view.ReadText("Digite el ingrediente: ");

            if (ingredient == "")
            {
                _view.ShowMessage("Debe escribir un ingrediente.");
                return;
            }

            List<Recipe> results = new List<Recipe>();

            foreach (Recipe recipe in _recipes)
            {
                if (recipe.HasIngredient(ingredient))
                {
                    results.Add(recipe);
                }
            }

            _view.ShowRecipes(results);
        }

        private void ShowRecipeDetail()
        {
            _view.ShowRecipes(_recipes);
            int id = _view.ReadNumber("Digite el número de la receta: ");
            int index = FindRecipeIndex(id);

            if (index == -1)
            {
                _view.ShowMessage("La receta no existe.");
                return;
            }

            _view.ShowRecipeDetail(_recipes[index]);
        }

        private void SaveRecipe()
        {
            _view.ShowRecipes(_recipes);
            int id = _view.ReadNumber("Digite el número de la receta que quiere guardar: ");
            int index = FindRecipeIndex(id);

            if (index == -1)
            {
                _view.ShowMessage("La receta no existe.");
                return;
            }

            if (_recipes[index].IsSaved())
            {
                _view.ShowMessage("La receta ya estaba guardada.");
                return;
            }

            _recipes[index].Save();
            _view.ShowMessage("Receta guardada en sus favoritas.");
        }

        private void ShowSavedRecipes()
        {
            List<Recipe> savedRecipes = new List<Recipe>();

            foreach (Recipe recipe in _recipes)
            {
                if (recipe.IsSaved())
                {
                    savedRecipes.Add(recipe);
                }
            }

            _view.ShowRecipes(savedRecipes);
        }

        private void ShareRecipe()
        {
            string author = _view.ReadText("Digite su nombre: ");
            string name = _view.ReadText("Digite el nombre de la receta: ");

            if (name == "")
            {
                _view.ShowMessage("El nombre de la receta no puede estar vacío.");
                return;
            }

            _view.ShowMealTypes(_mealTypes);
            int mealTypeOption = _view.ReadNumber("Seleccione el tipo de comida: ");

            if (mealTypeOption < 1 || mealTypeOption > _mealTypes.Length)
            {
                _view.ShowMessage("Tipo de comida no válido.");
                return;
            }

            string ingredients = _view.ReadText("Digite los ingredientes separados por coma: ");
            string preparation = _view.ReadText("Digite la preparación: ");

            AddRecipe(name, _mealTypes[mealTypeOption - 1], ingredients, preparation, author);

            _view.ShowMessage("¡Receta compartida! Ahora todos los usuarios la pueden ver.");
            _view.ShowRecipeDetail(_recipes[_recipes.Count - 1]);
        }

        private int FindRecipeIndex(int id)
        {
            for (int i = 0; i < _recipes.Count; i++)
            {
                if (_recipes[i].GetId() == id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
