using RCookBookDB.okna;
using RevCookBook.Classes;
using RevCookBook.Handlers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            try
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
            catch (Exception e)
            {
                ErrorLogHandler.SaveErrorToLog(e);
                MessageBox.Show("Wystąpił błąd podczas wyszukiwania kategorii! Raport błędu został zapisany. Proszę wysłać go do developera, bardzo pomoże to w rozwoju programu (:", "Błąd wyszukiwania kategorii");
            }
           
        }

        private void SelectionChanged()
        {
            new AddCategory(selectedItem).ShowDialog();
        }
    }
}
