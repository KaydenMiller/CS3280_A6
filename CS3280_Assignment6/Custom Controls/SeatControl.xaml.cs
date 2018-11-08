using CS3280_Assignment6.ViewModels;
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

namespace CS3280_Assignment6.CustomControls
{
    /// <summary>
    /// Interaction logic for Seat.xaml
    /// </summary>
    public partial class SeatControl : UserControl
    {
        private SeatingGrid SeatingGrid;

        public event Action<int> SeatSelected; 

        public SeatControl(SeatingGrid seatingGrid)
        {
            SeatingGrid = seatingGrid;
            InitializeComponent();
            DataContext = new SeatViewModel();
        }

        public SeatControl(SeatingGrid seatingGrid, SeatViewModel viewModel)
        {
            SeatingGrid = seatingGrid;
            InitializeComponent();
            DataContext = viewModel;
        }

        private void btnSeat_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as SeatViewModel).SeatSelected = true;
            SeatSelected?.Invoke((DataContext as SeatViewModel).SeatID);
        }
    }
}
