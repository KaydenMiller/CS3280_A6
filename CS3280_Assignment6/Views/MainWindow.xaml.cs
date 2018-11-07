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
using CS3280_Assignment6.Models;

namespace CS3280_Assignment6.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Aircraft> Aircraft { get; set; } = new List<Aircraft>();
        public ViewModels.SeatingGridViewModel SeatingGridViewModel { get; set; } = new ViewModels.SeatingGridViewModel();

        private Aircraft _selectedAircraft;
        public Aircraft SelectedAircraft
        {
            get => _selectedAircraft;
            set
            {
                _selectedAircraft = value;
                SeatingGridViewModel.Aircraft = _selectedAircraft;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            foreach (Flight flight in Controllers.FlightController.GetAllFlights())
            {
                Aircraft aircraft = new Aircraft(flight, 12, 4, 1);
                Aircraft.Add(aircraft);
            }
        }
    }
}
