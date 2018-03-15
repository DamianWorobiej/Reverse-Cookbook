using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RevCookBook.Classes;
using RevCookBook.Handlers;
using RCookBookDB.okna;
using System.Collections.ObjectModel;
using System.Windows;

namespace RevCookBook.View_Models
{
    class AddIngredientViewModel
    {
        private Category selectedCategory;
        private string name;
        private bool vegan;
        private int state;
        private CategoryHandler ch;
        private IngredientHandler ih;
        private Ingredient ingredient;
        private string catSearch;

        public Category SelectedCategory { get => selectedCategory; set => selectedCategory = value; }
        public bool Vegan { get => vegan; set => vegan = value; }
        public ObservableCollection<Category> Collection { get; set; }
        public int State { get => state; set => state = value; }
        public string Name { get => name; set => name = value; }
        public Ingredient Ingredient { get => ingredient; set => ingredient = value; }
        public string CatSearch { get => catSearch; set => catSearch = value; }

        public AddIngredientViewModel()
        {
            state = 0;
            ch = new CategoryHandler();
            ih = new IngredientHandler();
            Collection = ch.GetObservable();
        }

        public AddIngredientViewModel(Ingredient ingredient)
        {
            this.ingredient = ingredient;
            name = ingredient.Name;
            state = 1;
            vegan = ingredient.Vegan;
            ch = new CategoryHandler();
            ih = new IngredientHandler();
            Collection = ch.GetObservable();
            selectedCategory = Collection.Single(x => x.ID.Equals(ingredient.CategoryID));
        }

        public void AddIngredient()
        {
            try
            {
                if (name != "" && name != null)
                {
                    if (selectedCategory != null)
                    {
                        ih.InsertData(new Ingredient(0, name, selectedCategory.ID, vegan.ToString(), true.ToString()));
                        RCookBookDB.AddIngredient.CloseAddIngredient();
                    }
                    else throw new Exception("Należy wybrać kategorię produktu!");
                }
                else throw new Exception("Należy wpisać nazwę składnika!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Błąd dodawania składnika");
            }
        }
        
        public void UpdateIngredient()
        {
            try
            {
                if (name != "" && name != null)
                {
                    if (selectedCategory != null)
                    {
                        ih.UpdateData(new Ingredient(ingredient.ID, name, selectedCategory.ID, vegan.ToString(), true.ToString()));
                        RCookBookDB.AddIngredient.CloseAddIngredient();
                    }
                    else throw new Exception("Należy wybrać kategorię produktu!");
                }
                else throw new Exception("Należy wpisać nazwę dania!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Błąd altualizacji składnika");
            }
        }

        public void ExecuteAction()
        {
            switch (state)
            {
                case 0:
                    AddIngredient();
                    break;
                case 1:
                    UpdateIngredient();
                    break;
                default:
                    break;
            }
        }

        public void FindCategoriesWithSetName(string name)
        {
            Collection.Clear();

            if (name == null || name == "")
            {
                var newCollection = ch.GetObservable();
                foreach (var ingredient in newCollection)
                {
                    Collection.Add(ingredient);
                }
            }
            else
            {
                var newCollection = ch.GetObservableOfCategoriesWithSetName(name);

                foreach (var ingredient in newCollection)
                {
                    Collection.Add(ingredient);
                }
            }
        }

        public void OpenAddCategory()
        {
            new AddCategory().ShowDialog();
            FindCategoriesWithSetName(catSearch);
        }
    }
}
