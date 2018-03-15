using RevCookBook.Classes;
using RevCookBook.Handlers;
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
    /// Logika interakcji dla klasy AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
       
        private AddCategoryViewModel _viewModel;

        public AddCategory()
        {
            InitializeComponent();
            _viewModel = new AddCategoryViewModel();
            DataContext = _viewModel;
            EventCloseAddCategoryWindow += new EventHandler(_closeAddCategoryWindow);
        }

        public AddCategory(Category category)
        {
            InitializeComponent();
            _viewModel = new AddCategoryViewModel(category);
            DataContext = _viewModel;
            EventCloseAddCategoryWindow += new EventHandler(_closeAddCategoryWindow);

            btn_OK.Content = "Aktualizuj kategorię";
            Title = "Aktualizacja kategorii";
        }

        public static event EventHandler EventCloseAddCategoryWindow;

        private void _closeAddCategoryWindow(object sender, EventArgs e)
        {
            Close();
        }
        public static void CloseAddCategoryWindow()
        {
            EventCloseAddCategoryWindow?.Invoke(null, new EventArgs());
        }

        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            switch (_viewModel.State)
            {
                case 0:
                    _viewModel.AddCategory();
                    break;
                case 1:
                    _viewModel.UpdateCategory();
                    break;
                default:
                    break;
            }
        }

        private void btn_Anuluj_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
