using RevCookBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using RevCookBook.View_Models;
using RevCookBook.Classes;

namespace RCookBookDB
{
    /// <summary>
    /// Logika interakcji dla klasy IngredientsToDishesWindow.xaml
    /// </summary>
    public partial class IngredientsToDishesWindow : Window
    {
        private MainWindow MainReference;
        private bool all;
        private IngredientsToDishesWindowViewModel _viewModel;
        private List<Ingredient> ingList;

        public bool All { get => all; set => all = value; }

        public static event EventHandler EventCloseIngredientsToDishesWindow;


        public IngredientsToDishesWindow(MainWindow main, bool all)
        {
            InitializeComponent();
            _viewModel = new IngredientsToDishesWindowViewModel(all);
            ingList = new List<Ingredient>();
            DataContext = _viewModel;
            EventCloseIngredientsToDishesWindow += new EventHandler(closeIngredientsToDishesWindow);

            MainReference = main;
            this.all = all;

            if (all) Title = "Dania zawierające wszystkie składniki";
            else Title = "Wszystkie dania zawierające składniki";
        }

        #region Closing

        private void closeIngredientsToDishesWindow(object sender, EventArgs e)
        {
            MainReference.Show();
            Close();
        }
        public static void CloseIngredientsToDishesWindow()
        {
            EventCloseIngredientsToDishesWindow?.Invoke(null, new EventArgs());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainReference.Show();
        }

        private void Btn_Close(object sender, RoutedEventArgs e)
        {
            CloseIngredientsToDishesWindow();
        }
        #endregion

        private void tb_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.FindIngredientsWithSetName(tb_Search.Text);
        }

        private void cbox_Vegan_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void IngredientsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Hh = new List<Ingredient>();
            foreach (var item in IngredientsListView.SelectedItems)
            {
                Hh.Add((Ingredient)item);
                
            }
            _viewModel.UpdateDishes(Hh);

            

        }

        private void Wybrane_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.SelectedDishChanged((Dish)Wybrane.SelectedItem);
        }
    }
}
