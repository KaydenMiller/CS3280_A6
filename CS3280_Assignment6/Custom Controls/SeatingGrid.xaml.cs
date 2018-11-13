using CS3280_Assignment6.Utilities;
using CS3280_Assignment6.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private SeatingGridViewModel SeatingGridViewModel { get; set; }

        public SeatingGrid()
        {
            InitializeComponent();

            DataContextChanged += OnDataContextChanged;
        }

        public void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Cast Datacontext to Seating Grid View Model
            SeatingGridViewModel = (DataContext as MainWindowViewModel).SeatingGridViewModel;

            SeatingGridViewModel.PropertyChanged += UpdateView;
        }

        public void UpdateView(object sender, PropertyChangedEventArgs e)
        {
            ClearData();
            var result = GenerateView();
            if (result.Result == OperationResultValue.Failure)
            {
                string message = "";
                foreach (string msg in result.Messages)
                    message += $" {msg}";
                throw new Exception(message);
            }
        }

        private void ClearData()
        {
            SeatingLayoutGrid.ColumnDefinitions.Clear();
            SeatingLayoutGrid.Children.Clear();
        }

        private OperationResult GenerateView()
        {
            OperationResult operationResult = new OperationResult();

            if (DataContext == null)
            {
                operationResult.Result = OperationResultValue.Failure;
                operationResult.Messages.Add("Empty Seating Grid View Model.");
                return operationResult;
            }

            // Cast Datacontext to Seating Grid View Model
            SeatingGridViewModel = (DataContext as MainWindowViewModel).SeatingGridViewModel;

            // Set Aircraft title
            AircraftTitle.Text = $"{SeatingGridViewModel.Aircraft.Flight_Number}, {SeatingGridViewModel.Aircraft.Aircraft_Type}";

            // Generate Seating Grid
            GenerateColumns(SeatingGridViewModel.Aircraft.Columns, SeatingGridViewModel.Aircraft.Aisles);
            GenerateAisles(SeatingGridViewModel.Aircraft.Columns, SeatingGridViewModel.Aircraft.Aisles);
            GenerateSeats(SeatingGridViewModel.Aircraft.Columns, SeatingGridViewModel.Aircraft.Aisles, SeatingGridViewModel.Aircraft.Seats);

            operationResult.Result = OperationResultValue.Success;
            return operationResult;
        }

        private void GenerateSeats(int cols, int aisles, IEnumerable<SeatViewModel> seats)
        {
            int seatsInCol = (seats.Count() / cols);
            int colsPerAisle = cols / (aisles + 1);
            int aisleOffset = 0;

            for (int column = 0; column < cols; column++)
            {
                StackPanel stackPanel = new StackPanel();

                if (column % colsPerAisle == 0 && column != 0)
                {
                    aisleOffset++;
                }

                List<SeatViewModel> seatViewModels = seats.ToList();
                for (int seat = column * seatsInCol; seat < (column + 1) * seatsInCol; seat++)
                {
                    SeatControl seatControl = new SeatControl(this, seatViewModels[seat]);
                    seatControl.Style = Resources["aircraft_seat_style"] as Style;
                    seatControl.SeatSelected += OnSeatSelected;

                    stackPanel.Children.Add(seatControl);
                }

                // Column becomes wrong after cols / aisles
                Grid.SetColumn(stackPanel, column + aisleOffset);
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

        public delegate void SeatSelectedEventHandler(object sender, SeatSelectedEventArgs e);
        public event SeatSelectedEventHandler SeatSelected
        {
            add { AddHandler(SeatSelectedEvent, value); }
            remove { RemoveHandler(SeatSelectedEvent, value); }
        }
        public static readonly RoutedEvent SeatSelectedEvent = EventManager.RegisterRoutedEvent(
            "SeatSelected", RoutingStrategy.Bubble, typeof(SeatSelectedEventHandler), typeof(SeatingGrid));

        private void OnSeatSelected(int seatID)
        {
            SeatingGridViewModel.SelectedSeatID = seatID;

            var query =
                from seatViewModel in SeatingGridViewModel.Aircraft.Seats
                where seatViewModel.SeatID != seatID
                select seatViewModel;

            foreach (SeatViewModel svm in query)
            {
                svm.SeatSelected = false;
            }

            RaiseEvent(new SeatSelectedEventArgs(seatID, SeatSelectedEvent));
        }
    }

    public class SeatSelectedEventArgs : RoutedEventArgs
    {
        public int SeatID { get; set; }

        public SeatSelectedEventArgs(int seatID, RoutedEvent routedEvent) : base (routedEvent)
        {
            SeatID = seatID;
        }
    }

}
