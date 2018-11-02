using CS3280_Assignment6.Utilities;
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
    /// Interaction logic for SeatingGrid.xaml
    /// </summary>
    public partial class SeatingGrid : UserControl
    {
        public SeatingGridViewModel SeatingGridViewModel { get; set; }

        public SeatingGrid()
        {
            InitializeComponent();
        }

        public void UpdateView()
        {
            var result = GenerateView();
            if (result.Result == OperationResultValue.Failure)
            {
                string message = "";
                foreach (string msg in result.Messages)
                    message += $" {msg}";
                throw new Exception(message);
            }
        }

        private OperationResult GenerateView()
        {
            OperationResult operationResult = new OperationResult();

            if (SeatingGridViewModel == null)
            {
                operationResult.Result = OperationResultValue.Failure;
                operationResult.Messages.Add("Empty Seating Grid View Model.");
                return operationResult;
            }

            // Set Aircraft title
            AircraftTitle.Text = SeatingGridViewModel.Aircraft.TaleNumber;

            // Generate Seating Grid
            GenerateColumns(SeatingGridViewModel.Aircraft.Columns, SeatingGridViewModel.Aircraft.Aisles);
            GenerateAisles(SeatingGridViewModel.Aircraft.Columns, SeatingGridViewModel.Aircraft.Aisles);
            GenerateSeats(SeatingGridViewModel.Aircraft.Columns, SeatingGridViewModel.Aircraft.Aisles, SeatingGridViewModel.Aircraft.Seats);
            

            operationResult.Result = OperationResultValue.Success;
            return operationResult;
        }

        private void GenerateSeats(int cols, int aisles, List<Models.Seat> seats)
        {
            int seatsInCol = seats.Count / cols;

            for (int column = 0; column < cols; column++)
            {
                StackPanel stackPanel = new StackPanel();

                for (int seat = column * seatsInCol; seat < (column + 1) * seatsInCol; seat++)
                {
                    SeatControl seatControl = new SeatControl();
                    seatControl.Seat = seats[seat];
                    seatControl.Style = Resources["aircraft_seat_style"] as Style;

                    stackPanel.Children.Add(seatControl);
                }
                // Column becomes wrong after cols / aisles
                Grid.SetColumn(stackPanel, column);
                SeatingLayoutGrid.Children.Add(stackPanel);
            }
        }

        private void GenerateColumns(int cols, int aisles)
        {
            for (int column = 0; column < cols; column++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                GridLength gridLength = new GridLength(1, GridUnitType.Auto);

                colDef.Width = gridLength;
                SeatingLayoutGrid.ColumnDefinitions.Add(colDef);
            }
        }

        private void GenerateAisles(int cols, int aisles)
        {
            ColumnDefinition colDef = new ColumnDefinition();
            GridLength gridLength = new GridLength(1, GridUnitType.Star);
            colDef.Width = gridLength;

            int colsPerAisle = cols / (aisles + 1);


            for (int pos = colsPerAisle; pos < cols; pos += colsPerAisle)
            {
                SeatingLayoutGrid.ColumnDefinitions.Insert(2, colDef);
            }
        }
    }
}
