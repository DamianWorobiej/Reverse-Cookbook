using RCookBookDB;
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
    class AddDishViewModel : INotifyPropertyChanged
    {
        private string ingredientsSearch;
        private Ingredient selectedIngredientAdd; // możliwe że do implementacji wielokrotnego zaznaczenia
        private Amount selectedIngredientToDish;  // możliwe że do implementacji wielokrotnego zaznaczenia
        private Dish dish;
        private string name;
        private string time;
        private string amount;
        private bool vegan;
        private int state;
        

        private IngredientHandler ih;
        private DishHandler dh;

        public ObservableCollection<Ingredient> IngredientsList { get; set; }
        public ObservableCollection<Amount> IngredientsListToDish { get; set; }
        public Ingredient SelectedIngredientAdd { get; set; }
        public Amount SelectedIngredientToDish { get; set; }

        public string IngredientsSearch
        {
            get => ingredientsSearch;
            set
            {
                ingredientsSearch = value;
                OnPropertyChanged("IngredientsSearch");
            }
        }

        public string Name { get => name; set => name = value; }
        public string Time { get => time; set => time = value; }
        public bool Vegan { get => vegan; set => vegan = value; }
        public string Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }
        public int State { get => state; set => state = value; }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Constructors
        public AddDishViewModel()
        {
            state = 0;
            ih = new IngredientHandler();
            dh = new DishHandler();
            IngredientsList = ih.GetObservable();
            IngredientsListToDish = new ObservableCollection<Amount>();

        }

        public AddDishViewModel(Dish dish)
        {
            state = 1;
            this.dish = dish;
            name = dish.Name;
            time = dish.Time;

            ih = new IngredientHandler();
            dh = new DishHandler();
            IngredientsList = ih.GetObservable();

            IngredientsListToDish = new ObservableCollection<Amount>();
            foreach (var ingredient in dish.Amount)
            {
                IngredientsListToDish.Add(new Amount(ingredient.Key, ingredient.Value));
            }
           
            var buffer = new List<int>();
            foreach (var ingredient in IngredientsListToDish)
            {
                for (int i = 0; i < IngredientsList.Count(); i++)
                {
                    if (IngredientsList[i].Name == ingredient.Ingredient.Name) buffer.Add(i);
                }
            }
            
            buffer.Sort();
            for (int i = buffer.Count(); i > 0; i--)
            {
                IngredientsList.RemoveAt(buffer[i - 1]);
            }
            
        }

        #endregion

        public void AddIngredientToDish()
        {
            try
            {
                if (SelectedIngredientAdd != null)
                {
                    IngredientsListToDish.Add(new Amount(SelectedIngredientAdd, Amount));
                    IngredientsList.Remove(SelectedIngredientAdd);
                    Amount = null;
                    IngredientsSearch = null;
                }
                else throw new Exception("Należy zaznaczyć składnik, aby dodać go do dania!"); //length 49
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    ErrorLogHandler.SaveErrorToLog(e);
                    MessageBox.Show("Błąd dodawania składnika do dania! Raport błędu został zapisanyw folderze " + Paths.SubPathErrorLogs + ". Proszę wysłać go do developera, bardzo pomoże to w rozwoju programu (:");
                }
                else MessageBox.Show(e.Message);
            }
        }

        public void RemoveIngredientFromDish()
        {
            try
            {
                if (SelectedIngredientToDish != null)
                {
                    IngredientsList.Add(SelectedIngredientToDish.Ingredient);
                    IngredientsListToDish.Remove(SelectedIngredientToDish);
                    SortIngListByName();
                }
                else throw new Exception("Należy zaznaczyć składnik, który chce się usunąć z dania!");
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    ErrorLogHandler.SaveErrorToLog(e);
                    MessageBox.Show("Błąd usuwania składnika z dania! Raport błędu został zapisanyw folderze " + Paths.SubPathErrorLogs + ". Proszę wysłać go do developera, bardzo pomoże to w rozwoju programu (:");
                }
                else MessageBox.Show(e.Message);
            }
        }

        private void SortIngListByName()
        {
            var Hh = IngredientsList.ToList();
            Hh.Sort((x, y) => string.Compare(x.Name, y.Name));
            IngredientsList.Clear();
            foreach (var ingredient in Hh)
            {
                IngredientsList.Add(ingredient);
            }


        }

        public void UpdateDish()
        {
            try
            {
                if (Name != "" && Name != null)
                {

                    if (IngredientsListToDish.Count() > 0 || (Time != "" && Time != null))
                    {
                        if (IngredientsListToDish.Count() > 0)
                        {
                            if (Time != "" && Time != null) subUpdateDish();
                            else
                            {
                                var decision = MessageBox.Show("Czy chcesz dodać danie nie zawierające czasu przygotowania? Możesz to później zmienić aktualizując dodawane danie.", "", MessageBoxButton.YesNo);
                                if (decision == MessageBoxResult.Yes) subUpdateDish();
                            }
                        }
                        else
                        {
                            var decision = MessageBox.Show("Czy chcesz dodać danie nie zawierające żadnych składników? Możesz to później zmienić aktualizując dodawane danie.", "", MessageBoxButton.YesNo);
                            if (decision == MessageBoxResult.Yes) subUpdateDish();
                        }
                        
                        
                    }
                    else
                    {
                        var decision = MessageBox.Show("Czy chcesz dodać danie nie zawierające czasu przygotowania ani żadnych składników? Możesz to później zmienić aktualizując dodawane danie.", "", MessageBoxButton.YesNo);
                        if (decision == MessageBoxResult.Yes) subUpdateDish();
                    }
                }
                else throw new Exception("Należy wpisać nazwę dania!");

                
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    ErrorLogHandler.SaveErrorToLog(e);
                    MessageBox.Show("Błąd aktualizacji dania! Raport błędu został zapisanyw folderze " + Paths.SubPathErrorLogs + ". Proszę wysłać go do developera, bardzo pomoże to w rozwoju programu (:");
                }
                else MessageBox.Show(e.Message, "Błąd aktualizacji dania");
            }
        }

        private void subUpdateDish()
        {
            dh.UpdateData(new Dish(dish.ID, Name, formDictionary(), Time));
            RCookBookDB.okna.AddDish.CloseAddDish();
        }

        public void AddDish()
        {
            try
            {
                if (Name != "" && Name != null)
                {
                    if (IngredientsListToDish.Count() > 0 || (Time != "" && Time != null))
                    {

                        if (IngredientsListToDish.Count() > 0)
                        {
                            if (Time != "" && Time != null) subAddDish();
                            else
                            {
                                var decision = MessageBox.Show("Czy chcesz dodać danie nie zawierające czasu przygotowania? Możesz to później zmienić aktualizując dodawane danie.", "", MessageBoxButton.YesNo);
                                if (decision == MessageBoxResult.Yes) subAddDish();
                            }
                        }
                        else
                        {
                            var decision = MessageBox.Show("Czy chcesz dodać danie nie zawierające żadnych składników? Możesz to później zmienić aktualizując dodawane danie.", "", MessageBoxButton.YesNo);
                            if (decision == MessageBoxResult.Yes) subAddDish();
                        }
                    }
                    else
                    {
                        var decision = MessageBox.Show("Czy chcesz dodać danie nie zawierające żadnych składników? Możesz to później zmienić aktualizując dodawane danie.", "", MessageBoxButton.YesNo);
                        if (decision == MessageBoxResult.Yes) subAddDish();
                        
                    }
                }
                else throw new Exception("Należy wpisać nazwę dania!");
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    ErrorLogHandler.SaveErrorToLog(e);
                    MessageBox.Show("Błąd dodawania dania! Raport błędu został zapisanyw folderze " + Paths.SubPathErrorLogs + ". Proszę wysłać go do developera, bardzo pomoże to w rozwoju programu (:");
                }
                else MessageBox.Show(e.Message, "Błąd dodawania dania");
            }
        }

        private void subAddDish()
        {
            dh.InsertData(new Dish(0, Name, formDictionary(), Time));
            RCookBookDB.okna.AddDish.CloseAddDish();
        }

        private Dictionary<Ingredient, string> formDictionary()
        {
            var Hh = new Dictionary<Ingredient, string>();
            foreach (var ingredient in IngredientsListToDish)
            {
                Hh.Add(ingredient.Ingredient, ingredient.Quantity);
            }
            return Hh;
        }

        public void OpenAddIngredient()
        {
            new AddIngredient().ShowDialog();
            
            FindIngredientsWithSetName(ingredientsSearch);
        }

        public void FindIngredientsWithSetName(string name)
        {
            try
            {
                ingredientsSearch = name;
                IngredientsList.Clear();

                if (name == null || name == "")
                {
                    var newIngredientsList = ih.GetObservable();
                    foreach (var ingredient in newIngredientsList)
                    {
                        IngredientsList.Add(ingredient);
                    }
                }
                else
                {
                    var newIngredientsList = ih.GetObservableOfIngredientsWithSetName(name);

                    foreach (var ingredient in newIngredientsList)
                    {
                        IngredientsList.Add(ingredient);
                    }
                }
                RemoveIngredientsIfInDish();
            }
            catch (Exception e)
            {
                ErrorLogHandler.SaveErrorToLog(e);
                MessageBox.Show("Wystąpił błąd podczas szukania składników! Raport błędu został zapisanyw folderze " + Paths.SubPathErrorLogs + ". Proszę wysłać go do developera, bardzo pomoże to w rozwoju programu (:");
            }
        }

        private void RemoveIngredientsIfInDish()
        {
            var Hh = new List<int>();
            foreach (var ing in IngredientsListToDish)
            {
                foreach (var ingredient in IngredientsList)
                {
                    if (ingredient.ID == ing.Ingredient.ID && !Hh.Contains(ing.Ingredient.ID)) Hh.Add(IngredientsList.IndexOf(ingredient));
                }
            }
            var Hh2 = Hh.OrderByDescending(x => x);
            foreach (var index in Hh)
            {
                IngredientsList.RemoveAt(index);
            }
        }
    }
}
