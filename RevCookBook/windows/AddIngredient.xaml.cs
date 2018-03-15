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

namespace RCookBookDB
{
    /// <summary>
    /// Logika interakcji dla klasy AddIngredient.xaml
    /// </summary>
    public partial class AddIngredient : Window
    {
        public bool Update;

        private AddIngredientViewModel _viewModel;

        public static event EventHandler EventCloseAddIngredient;

        public AddIngredient()
        {
            InitializeComponent();
            _viewModel = new AddIngredientViewModel();
            DataContext = _viewModel;

            Title = "Dodaj składnik";
            EventCloseAddIngredient += new EventHandler(closeAddIngredient);
            Update = false;
        }

        public AddIngredient(Ingredient ing)
        {
            InitializeComponent();

            _viewModel = new AddIngredientViewModel(ing);
            DataContext = _viewModel;

            Title = "Aktualizuj składnik";
            btn_AddIng.Content = "Aktualizuj składnik";

            if (ing.Vegan) cbox_Meat.IsChecked = false;
            else cbox_Meat.IsChecked = true;

            EventCloseAddIngredient += new EventHandler(closeAddIngredient);
            Update = false;
        }

        private void closeAddIngredient(object sender, EventArgs e)
        {
            Close();
        }
        public static void CloseAddIngredient()
        {
            EventCloseAddIngredient?.Invoke(null, new EventArgs());
        }

        private void tb_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.CatSearch = tb_Search.Text;
            _viewModel.FindCategoriesWithSetName(tb_Search.Text);
        }

        private void btn_AddIng_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ExecuteAction();
            Update = true;
        }

        private void btn_AddCategory_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenAddCategory();
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Update = false;
            Close();
        }
    }
}
