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

namespace CS3280_Assignment6.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Models.Aircraft> Aircraft { get; set; } = new List<Models.Aircraft>();
        public ViewModels.SeatingGridViewModel SeatingGridViewModel { get; set; } = new ViewModels.SeatingGridViewModel();

        private Models.Aircraft _selectedAircraft;
        public Models.Aircraft SelectedAircraft
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

            Aircraft.Add(new Models.Aircraft()
            {
                ID = 0,
                TaleNumber = "654",
                TotalSeats = 16,
                Columns = 4,
                Aisles = 1
            });
            Aircraft.Add(new Models.Aircraft
            {
                ID = 1,
                TaleNumber = "747",
                TotalSeats = 20,
                Columns = 4,
                Aisles = 1
            });
        }
    }
}
