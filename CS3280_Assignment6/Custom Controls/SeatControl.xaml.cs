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
using CS3280_Assignment6.Utilities.Extensions;

namespace CS3280_Assignment6.CustomControls
{
    /// <summary>
    /// Interaction logic for Seat.xaml
    /// </summary>
    public partial class SeatControl : UserControl
    {
        /// <summary>
        /// The seating grid that this control is assigned to
        /// </summary>
        private SeatingGrid SeatingGrid;

        /// <summary>
        /// Event to notify when this seat is selected
        /// </summary>
        public event Action<int> SeatSelected; 

        /// <summary>
        /// Plain Contructor
        /// </summary>
        /// <param name="seatingGrid"></param>
        public SeatControl(SeatingGrid seatingGrid)
        {
            try
            {
                SeatingGrid = seatingGrid;
                InitializeComponent();
                DataContext = new SeatViewModel();
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        /// <summary>
        /// Constructor with ViewModel
        /// </summary>
        /// <param name="seatingGrid"></param>
        /// <param name="viewModel"></param>
        public SeatControl(SeatingGrid seatingGrid, SeatViewModel viewModel)
        {
            try
            {
                SeatingGrid = seatingGrid;
                InitializeComponent();
                DataContext = viewModel;
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        /// <summary>
        /// Click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (DataContext as SeatViewModel).SeatSelected = true;
                SeatSelected?.Invoke((DataContext as SeatViewModel).SeatID);
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }
    }
}
