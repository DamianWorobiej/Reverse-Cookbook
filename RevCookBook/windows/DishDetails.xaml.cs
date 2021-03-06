﻿using RevCookBook.Classes;
using RevCookBook.Handlers;
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
    /// Logika interakcji dla klasy DishDetails.xaml
    /// </summary>
    public partial class DishDetails : Window
    {
        DishDetailsViewModel _viewModel;

        public DishDetails(Dish input)
        {
            InitializeComponent();
            _viewModel = new DishDetailsViewModel(input);
            DataContext = _viewModel;
        }

        private void Btn_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
