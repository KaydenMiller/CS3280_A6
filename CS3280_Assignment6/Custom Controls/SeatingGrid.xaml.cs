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
using CS3280_Assignment6.Utilities.Extensions;
using System.Windows.Shapes;

namespace CS3280_Assignment6.CustomControls
{
    /// <summary>
    /// Interaction logic for SeatingGrid.xaml
    /// </summary>
    public partial class SeatingGrid : UserControl
    {
        /// <summary>
        /// The viewmodel for the seating grid
        /// </summary>
        private SeatingGridViewModel SeatingGridViewModel { get; set; }

        /// <summary>
        /// Contstructor
        /// </summary>
        public SeatingGrid()
        {
            try
            {
                InitializeComponent();

                DataContextChanged += OnDataContextChanged;
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        /// <summary>
        /// EventHandler for when the datacontext changes to a different aircraft
        /// there may be a way to remove this now
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                // Cast Datacontext to Seating Grid View Model
                SeatingGridViewModel = (DataContext as MainWindowViewModel).SeatingGridViewModel;

                SeatingGridViewModel.PropertyChanged += UpdateView;
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        /// <summary>
        /// Update the view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UpdateView(object sender, PropertyChangedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        /// <summary>
        /// Clear data
        /// </summary>
        private void ClearData()
        {
            try
            {
                SeatingLayoutGrid.ColumnDefinitions.Clear();
                SeatingLayoutGrid.Children.Clear();
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        // The following section of code is used for generation of the Control UI as different aircraft have 
        // different numbers of seats in a differnt layout this will provide that flexiblity
        #region UI_Generation

        /// <summary>
        /// Generates the view
        /// </summary>
        /// <returns></returns>
        private OperationResult GenerateView()
        {
            OperationResult operationResult = new OperationResult();

            try
            {
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
            }
            catch (Exception ex)
            {
                ex.Log();
            }

            return operationResult;
        }

        /// <summary>
        /// Generates the seats within the columns
        /// </summary>
        /// <param name="cols"></param>
        /// <param name="aisles"></param>
        /// <param name="seats"></param>
        private void GenerateSeats(int cols, int aisles, IEnumerable<SeatViewModel> seats)
        {
            try
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
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        /// <summary>
        /// Generate the UI Columns
        /// </summary>
        /// <param name="cols"></param>
        /// <param name="aisles"></param>
        private void GenerateColumns(int cols, int aisles)
        {
            try
            {

                for (int column = 0; column < cols; column++)
                {
                    ColumnDefinition colDef = new ColumnDefinition();
                    GridLength gridLength = new GridLength(1, GridUnitType.Auto);

                    colDef.Width = gridLength;
                    SeatingLayoutGrid.ColumnDefinitions.Add(colDef);
                }
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        /// <summary>
        /// Generate the Aisles
        /// </summary>
        /// <param name="cols"></param>
        /// <param name="aisles"></param>
        private void GenerateAisles(int cols, int aisles)
        {
            try
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
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        #endregion

        // UI Routed Event for notifying the system that a seat has been selected and providing relivant information
        public delegate void SeatSelectedEventHandler(object sender, SeatSelectedEventArgs e);
        public event SeatSelectedEventHandler SeatSelected
        {
            add { AddHandler(SeatSelectedEvent, value); }
            remove { RemoveHandler(SeatSelectedEvent, value); }
        }
        public static readonly RoutedEvent SeatSelectedEvent = EventManager.RegisterRoutedEvent(
            "SeatSelected", RoutingStrategy.Bubble, typeof(SeatSelectedEventHandler), typeof(SeatingGrid));

        /// <summary>
        /// Event handler for when a seat within the control is selected
        /// Will raise event to the UI and use the RoutedEvent system
        /// </summary>
        /// <param name="seatID"></param>
        private void OnSeatSelected(int seatID)
        {
            try
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
            catch (Exception ex)
            {
                ex.Log();
            }
        }
    }

    /// <summary>
    /// Class for the seatSelected RoutedEvent
    /// </summary>
    public class SeatSelectedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// The seatID
        /// </summary>
        public int SeatID { get; set; }

        public SeatSelectedEventArgs(int seatID, RoutedEvent routedEvent) : base (routedEvent)
        {
            SeatID = seatID;
        }
    }

}
