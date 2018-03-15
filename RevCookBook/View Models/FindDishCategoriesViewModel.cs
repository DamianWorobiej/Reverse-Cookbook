using RCookBookDB.okna;
using RevCookBook.Classes;
using RevCookBook.Handlers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevCookBook.View_Models
{
    class FindDishCategoriesViewModel
    {
        private Category selectedItem;
        private string nameSearch;
        private bool vegan;

        private CategoryHandler ch;

        public ObservableCollection<Category> Collection { get; private set; }
        public Category SelectedItem { get => selectedItem;
            set
            {
                selectedItem = value;
                SelectionChanged();
            }
        }
        public string NameSearch { get => nameSearch; set => nameSearch = value; }
        public bool Vegan { get => vegan; set => vegan = value; }


        public FindDishCategoriesViewModel()
        {
            ch = new CategoryHandler();
            Collection = ch.GetObservable();
        }

        public void FindItemsWithSetName(string name)
        {

            if (name == null) Collection = ch.GetObservable();
            else
            {
                var newCollection = ch.GetObservableOfCategoriesWithSetName(name);
                Collection.Clear();

                foreach (var item in newCollection)
                {
                    Collection.Add(item);
                }
            }
           
        }

        private void SelectionChanged()
        {
            new AddCategory(selectedItem).ShowDialog();
        }
    }
}
