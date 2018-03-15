using RevCookBook;
using RevCookBook.View_Models;
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

namespace RCookBookDB
{
    /// <summary>
    /// Logika interakcji dla klasy FindDish.xaml
    /// </summary>
    public partial class FindDish : Window
    {
        private int State;
        private MainWindow MainReference;
        private FindDishDishesViewModel _dishesViewModel;
        private FindDishCategoriesViewModel _categoriesViewModel;
        private FindDishIngredientsViewModel _ingredientsViewModel;



        public FindDish(MainWindow main, int state)
        {
            InitializeComponent();

            MainReference = main;
            State = state;
            SetTittleAndViewModel(State);
            EventCloseFindDishWindow += new EventHandler(_closeFindDishWindow);
        }

        public static event EventHandler EventCloseFindDishWindow;

        private void _closeFindDishWindow(object sender, EventArgs e)
        {
            Close();
        }
        public static void CloseFindDishWindow()
        {
            EventCloseFindDishWindow?.Invoke(null, new EventArgs());
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            CloseFindDishWindow();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainReference.Show();
        }

        private void tb_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_dishesViewModel != null) _dishesViewModel.FindItemsWithSetName(tb_Name.Text);
            if (_ingredientsViewModel != null) _ingredientsViewModel.FindItemsWithSetName(tb_Name.Text);
            if (_categoriesViewModel != null) _categoriesViewModel.FindItemsWithSetName(tb_Name.Text);
        }

        private void cbox_Meat_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void lv_Dishes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (State)
            {
                case 0:
                    break;
                default:
                    break;
            }
        }


        private void SetTittleAndViewModel(int state)
        {
            switch (state)
            {
                case 0:
                    Title = "Lista dań";
                    _dishesViewModel = new FindDishDishesViewModel(State);
                    DataContext = _dishesViewModel;
                    break;
                case 1:
                    Title = "Wybór dania do zaktualizowania";
                    _dishesViewModel = new FindDishDishesViewModel(State);
                    DataContext = _dishesViewModel;
                    break;
                case 2:
                    Title = "Wybór dania do usunięcia";
                    _dishesViewModel = new FindDishDishesViewModel(State);
                    DataContext = _dishesViewModel;
                    break;
                case 3:
                    Title = "Wybór składnika do zaktualizowania";
                    l_wyszukaj.Content = "Wyszukaj składnik po nazwie";
                    l_lista.Content = "Lista składników";
                    l_danie.Visibility = Visibility.Hidden;
                    cbox_Meat.Visibility = Visibility.Hidden;

                    _ingredientsViewModel = new FindDishIngredientsViewModel(State);
                    DataContext = _ingredientsViewModel;

                    break;
                case 4:
                    Title = "Wybór składnika do usunięcia";
                    l_wyszukaj.Content = "Wyszukaj składnik po nazwie";
                    l_lista.Content = "Lista składników";
                    l_danie.Visibility = Visibility.Hidden;
                    cbox_Meat.Visibility = Visibility.Hidden;

                    _ingredientsViewModel = new FindDishIngredientsViewModel(State);
                    DataContext = _ingredientsViewModel;
                    break;
                case 8:
                    Title = "Wybór kategorii do zaktualizowania";
                    l_wyszukaj.Content = "Wyszukaj kategorię po nazwie";
                    l_lista.Content = "Lista kategorii";
                    l_danie.Visibility = Visibility.Hidden;
                    cbox_Meat.Visibility = Visibility.Hidden;

                    _categoriesViewModel = new FindDishCategoriesViewModel();
                    DataContext = _categoriesViewModel;                    
                    break;
                default:
                    break;
            }
        }
    }
}
