﻿using System;
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
using CS3280_Assignment6.CustomControls;
using CS3280_Assignment6.Models;
using CS3280_Assignment6.ViewModels;

namespace CS3280_Assignment6.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void AddPassenger_Click(object sender, RoutedEventArgs e)
        {
            CreatePassengerWindow createPassengerWindow = new CreatePassengerWindow();
            createPassengerWindow.Show();
        }

        public void SeatingGrid_SeatSelected(object sender, SeatSelectedEventArgs e)
        {

        }
    }
}
