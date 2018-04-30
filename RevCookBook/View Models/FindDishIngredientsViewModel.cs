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
    class FindDishIngredientsViewModel
    {
        private int state;
        private Ingredient selectedItem;
        private string nameSearch;
        private IngredientHandler ih;
        private DishHandler dh;
        private bool vegan;


        public ObservableCollection<Ingredient> Collection { get; set; }
        public int State { get => state; set => state = value; }
        public Ingredient SelectedItem { get => selectedItem;
            set
            {
                selectedItem = value;
                SelectionChanged();
            }
        }
        public string NameSearch { get => nameSearch; set => nameSearch = value; }
        public bool Vegan { get => vegan; set => vegan = value; }

        public FindDishIngredientsViewModel(int state)
        {
            this.state = state;
            ih = new IngredientHandler();
            dh = new DishHandler();
            Collection = ih.GetObservable();
        }

        private void SelectionChanged()
        {
            switch (state)
            { 
                case 3:
                    new AddIngredient(selectedItem).ShowDialog();
                    break;
                case 4:
                    try
                    {
                        var IDel = MessageBox.Show("Czy na pewno chcesz usunąć składnik " + selectedItem.Name + "?", "", MessageBoxButton.YesNo);
                        if (IDel == MessageBoxResult.Yes)
                        {
                            var checker = dh.CheckDeleteIngredientConflicts(selectedItem);
                            if (checker.Count() != 0)
                            {
                                string names = null;
                                int i = 0;
                                foreach (var dish in checker)
                                {
                                    names += dh.DList.Single(x => x.ID == dish).Name;
                                    if (i + 1 == checker.Count()) break;
                                    else names += ", ";
                                }
                                var conflict = MessageBox.Show("Usuwany składnik znajduje się w: " + names + ". Usunięcie tego składnika spowoduje usunięcie go z tych dań. Czy mimo to chcesz kontynuować?", "", MessageBoxButton.YesNo);
                                if (conflict == MessageBoxResult.Yes)
                                {
                                    dh.DeleteIngredient(checker, selectedItem);
                                    ih.DeleteData(selectedItem.ID);
                                    if (ih.Close) FindDish.CloseFindDishWindow();
                                }
                            }
                            else
                            {
                                ih.DeleteData(selectedItem.ID);
                                if (ih.Close) FindDish.CloseFindDishWindow();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ErrorLogHandler.SaveErrorToLog(e);
                        MessageBox.Show("Wystąpił błąd usuwania składnika! Raport błędu został zapisany. Proszę wysłać go do developera, bardzo pomoże to w rozwoju programu (:", "Błąd usuwania składnika");
                    }
                    break;
                default:
                    break;
            }
        }

        public void FindItemsWithSetName(string name)
        {
            try
            {
                if (name == null) Collection = ih.GetObservable();
                else
                {
                    var newCollection = ih.GetObservableOfIngredientsWithSetName(name);
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
                MessageBox.Show("Wystąpił błąd podczas wyszukiwania! Raport błędu został zapisany. Proszę wysłać go do developera, bardzo pomoże to w rozwoju programu (:", "Błąd wyszukiwania");
            }
        }

    }
}
