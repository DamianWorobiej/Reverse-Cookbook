using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RevCookBook.Classes;
using RevCookBook.Handlers;
using RCookBookDB.okna;
using System.Collections.ObjectModel;
using RCookBookDB;
using System.Windows;

namespace RevCookBook.View_Models
{
    class IngredientsToDishesWindowViewModel
    {
        private Dish selectedDish;
        private Ingredient selectedIngredient;
        private IngredientHandler ih;
        private DishHandler dh;
        private bool state;
        private List<Ingredient> selectedIngredientsList;

        public ObservableCollection<Dish> Dishes { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public Dish SelectedDish { get => selectedDish;
            set
            {
                selectedDish = value;
                SelectedDishChanged();
            }
        }

        private void SelectedDishChanged()
        {
            throw new NotImplementedException();
        }

        public Ingredient SelectedIngredient { get => selectedIngredient;
            set
            {
                selectedIngredient = value;
                SelectedIngredientChanged();
            }
        }
        public bool State { get => state; set => state = value; }




        public IngredientsToDishesWindowViewModel(bool state)
        {
            this.state = state;
            ih = new IngredientHandler();
            dh = new DishHandler();
            selectedIngredientsList = new List<Ingredient>();

            Ingredients = ih.GetObservable();
            Dishes = dh.GetObservable();
        }

        private void SelectedIngredientChanged()
        {
            if (selectedIngredientsList.Contains(selectedIngredient)) selectedIngredientsList.Remove(selectedIngredient);
            else selectedIngredientsList.Add(selectedIngredient);
            string Hh = null;
            foreach (var item in selectedIngredientsList)
            {
                Hh += item.Name + ", ";
            }
            MessageBox.Show(Hh);
        }

        public void UpdateDishes(List<Ingredient> ingList)
        {
            Dishes.Clear();
            if (state)
            {
                if (ingList.Count() > 0)
                {
                    var Hh = dh.GetDishesWithAllSelectedIngredients(ingList);
                    foreach (var dish in Hh)
                    {
                        Dishes.Add(dish);
                    }
                }

                else
                {
                    var Hh = dh.GetObservable();
                    foreach (var dish in Hh)
                    {
                        Dishes.Add(dish);
                    }
                }
            }
            else
            {
                if (ingList.Count() > 0)
                {
                    var Hh = dh.GetDishesWithSelectedIngredients(ingList);
                    foreach (var dish in Hh)
                    {
                        Dishes.Add(dish);
                    }
                }

                else
                {
                    var Hh = dh.GetObservable();
                    foreach (var dish in Hh)
                    {
                        Dishes.Add(dish);
                    }
                }
            }
        }

        public void FindIngredientsWithSetName(string name)
        {
            Ingredients.Clear();

            if (name == null || name == "")
            {
                var newIngredients = ih.GetObservable();
                foreach (var ingredient in newIngredients)
                {
                    Ingredients.Add(ingredient);
                }
            }
            else
            {
                var newIngredients = ih.GetObservableOfIngredientsWithSetName(name);

                foreach (var ingredient in newIngredients)
                {
                    Ingredients.Add(ingredient);
                }
            }
        }

        public void SelectedDishChanged(Dish picked)
        {
            new DishDetails(picked).ShowDialog();
        }
    }
}
