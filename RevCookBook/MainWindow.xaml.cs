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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data.SQLite;
using RevCookBook.Handlers;
using RevCookBook.Classes;
using RCookBookDB;
using RCookBookDB.okna;
//using RevCookBook.windows;

namespace RevCookBook
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btn_ViewDishesWithAllIngs_Click(object sender, RoutedEventArgs e)
        {
            new IngredientsToDishesWindow(this,true).Show(); 
            Hide();

        }

        private void btn_ViewAllDishesWithSelectedIngs_Click(object sender, RoutedEventArgs e)
        {
            new IngredientsToDishesWindow(this,false).Show(); 
            Hide();
        }

        private void btn_FindDishes_Click(object sender, RoutedEventArgs e)
        {
            new FindDish(this, 0).Show();
            Hide();
        }


        #region Menu
        private void menu_AddIng(object sender, RoutedEventArgs e)
        {
            new AddIngredient().Show();
            
        }

        private void menu_UpdateIng(object sender, RoutedEventArgs e)
        {
            new FindDish(this, 3).ShowDialog();
        }

        private void menu_DeleteIng(object sender, RoutedEventArgs e)
        {
            new FindDish(this, 4).ShowDialog(); 
        }

        private void menu_AddDish(object sender, RoutedEventArgs e)
        {
            new AddDish().Show();
        }

        private void menu_UpdateDish(object sender, RoutedEventArgs e)
        {
            new FindDish(this, 1).ShowDialog(); 
        }

        private void menu_DeleteDish(object sender, RoutedEventArgs e)
        {
            new FindDish(this, 2).ShowDialog(); 
        }

        private void menu_AddCategory(object sender, RoutedEventArgs e)
        {
            new AddCategory().Show();
        }

        private void menu_UpdateCategory(object sender, RoutedEventArgs e)
        {
            new FindDish(this, 8).ShowDialog(); 
        }
        #endregion
    }
}
