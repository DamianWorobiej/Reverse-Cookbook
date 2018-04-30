using RCookBookDB;
using RCookBookDB.okna;
using RevCookBook.Classes;
using RevCookBook.Handlers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RevCookBook.View_Models
{
    public class FindDishDishesViewModel : INotifyPropertyChanged
    {
        private Dish selectedItem;
        private string nameSearch;
        private bool vegan;
        private int state;
        private DishHandler dh;

        public ObservableCollection<Dish> Collection { get; set; }
        public bool Close;
        public Dish SelectedItem { get { return selectedItem; }
            set
            {
                selectedItem = value;
                SelectionChanged();
            }
        }
        public string NameSearch { get { return nameSearch; }
            set
            {
                nameSearch = value;
                OnPropertyChanged("NameSearch");
            }
        }
        public bool Vegan { get => vegan;
            set
            {
                vegan = value;
                FindItemsWithSetName(nameSearch);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        
        public event PropertyChangedEventHandler PropertyChanged;

        public FindDishDishesViewModel(int state)
        {
            this.state = state;
            dh = new DishHandler();
            Collection = dh.GetObservable();
            Close = false;
        }

        private void SelectionChanged()
        {
            switch (state)
            {
                case 0:
                    try
                    {
                        new DishDetails(selectedItem).ShowDialog();
                    }
                    catch (Exception e)
                    {
                        ErrorLogHandler.SaveErrorToLog(e);
                        MessageBox.Show(e.Message);
                    }
                    break;
                case 1:
                    var temp = new AddDish(selectedItem).ShowDialog();
                    break;
                case 2:
                    try
                    {
                        var DDel = MessageBox.Show("Czy jesteś pewien, że chcesz usunąć danie " + SelectedItem.Name + "?", " ", MessageBoxButton.YesNo);
                        if (DDel == MessageBoxResult.Yes)
                        {
                            dh.DeleteData(selectedItem.ID);
                            if (dh.Close == true) FindDish.CloseFindDishWindow();
                        }
                    }
                    catch (Exception e)
                    {
                        ErrorLogHandler.SaveErrorToLog(e);
                        MessageBox.Show("Wystąpił błąd podczas usuwania dania! Raport błędu został zapisanyw folderze " + Paths.SubPathErrorLogs + ". Proszę wysłać go do developera, bardzo pomoże to w rozwoju programu (:", "Problem z usuwaniem dania!");
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
                nameSearch = name;
                if (!vegan)
                {
                    if (name == null) Collection = dh.GetObservable();
                    else
                    {
                        var newCollection = dh.GetObservableOfDishesWithSetNames(name);
                        Collection.Clear();

                        foreach (var item in newCollection)
                        {
                            Collection.Add(item);
                        }
                    }
                }
                else
                {
                    if (name == null || name == "") Collection = dh.GetVeganObservable();
                    else
                    {
                        var newCollection = dh.GetObservableOfVeganDishesWithSetNames(name);
                        Collection.Clear();

                        foreach (var item in newCollection)
                        {
                            Collection.Add(item);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ErrorLogHandler.SaveErrorToLog(e);
                MessageBox.Show("Wystąpił błąd podczas wyszukiwania dań! Raport błędu został zapisanyw folderze " + Paths.SubPathErrorLogs + ". Proszę wysłać go do developera, bardzo pomoże to w rozwoju programu (:", "Błąd wyszukiwania");
            }
            
        }

        

    }
}
