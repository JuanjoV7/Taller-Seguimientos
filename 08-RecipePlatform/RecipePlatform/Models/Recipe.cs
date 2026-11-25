using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePlatform.Models
{
    public class Recipe
    {
        private int _id;
        private string _name;
        private string _mealType;
        private string _ingredients;
        private string _preparation;
        private string _author;
        private bool _isSaved;

        public Recipe(int id, string name, string mealType, string ingredients, string preparation, string author)
        {
            _id = id;
            _name = name;
            _mealType = mealType;
            _ingredients = ingredients;
            _preparation = preparation;
            _author = author;
            _isSaved = false;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetMealType()
        {
            return _mealType;
        }

        public string GetIngredients()
        {
            return _ingredients;
        }

        public string GetPreparation()
        {
            return _preparation;
        }

        public string GetAuthor()
        {
            return _author;
        }

        public bool IsSaved()
        {
            return _isSaved;
        }

        public void Save()
        {
            _isSaved = true;
        }

        public bool NameContains(string text)
        {
            return _name.ToLower().Contains(text.ToLower());
        }

        public bool HasIngredient(string ingredient)
        {
            return _ingredients.ToLower().Contains(ingredient.ToLower());
        }
    }
}
