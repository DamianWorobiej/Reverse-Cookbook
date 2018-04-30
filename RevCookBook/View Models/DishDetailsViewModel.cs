using RevCookBook.Classes;
using RevCookBook.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevCookBook.View_Models
{
    class DishDetailsViewModel
    {
        private string dishName;
        private string dishTime;
        private Dictionary<Ingredient, string> dishIngList;
        private bool vegan;

        public string DishName { get => dishName; set => dishName = value; }
        public string DishTime { get => dishTime; set => dishTime = value; }
        public Dictionary<Ingredient, string> DishIngList { get => dishIngList; }
        public bool Vegan { get => vegan; }

        public DishDetailsViewModel(Dish input)
        {
            dishName = input.Name;
            dishTime = input.Time;
            dishIngList = new Dictionary<Ingredient, string>();
            foreach (var ing in input.Amount)
            {
                DishIngList.Add(ing.Key, ing.Value);
            }
            vegan = input.Vegan;
        }

        
    }
}
