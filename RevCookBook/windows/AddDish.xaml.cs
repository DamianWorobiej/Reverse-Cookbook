using RevCookBook.Classes;
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

namespace RCookBookDB.okna
{
    /// <summary>
    /// Logika interakcji dla klasy AddDish.xaml
    /// </summary>
    public partial class AddDish : Window
    {
        private AddDishViewModel _viewModel;
        public bool Update;

        public static event EventHandler EventCloseAddDish;

        public AddDish()
        {
            InitializeComponent();

            Title = "Dodawanie dania";
            _viewModel = new AddDishViewModel();
            DataContext = _viewModel;
            EventCloseAddDish += new EventHandler(closeAddDish);
            Update = false;
        }

        public AddDish(Dish dish)
        {
            InitializeComponent();
            _viewModel = new AddDishViewModel(dish);
            DataContext = _viewModel;
            Title =  "Aktualizacja dania";
            btn_Add.Content = "Zaktualizuj danie";
            Update = false;
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {

            switch (_viewModel.State)
            {
                case 0:
                    _viewModel.AddDish();
                    Update = true;
                    break;
                case 1:
                    _viewModel.UpdateDish();
                    Update = true;
                    break;
                default:
                    break;
            }
        }

        private void closeAddDish(object sender, EventArgs e)
        {
            Close();
        }
        public static void CloseAddDish()
        {
            EventCloseAddDish?.Invoke(null, new EventArgs());
        }

        private void btn_AddIng_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenAddIngredient();
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_AddIngToDish_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddIngredientToDish();
        }

        private void btn_RemoveIngToDish_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RemoveIngredientFromDish();
        }

        private void tb_Saerch_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.FindIngredientsWithSetName(tb_Saerch.Text);
        }
    }
}
