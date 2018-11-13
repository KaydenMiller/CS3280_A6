using CS3280_Assignment6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.ViewModels
{
    /// <summary>
    /// View model for the MainWindow
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// List of aircraft
        /// </summary>
        public List<Aircraft> Aircraft { get; set; } 
        /// <summary>
        /// The view model for the seating grid (i wonder if there is a better way to do that)
        /// </summary>
        public SeatingGridViewModel SeatingGridViewModel { get; set; }

        private string _selectedPassengerSeatID = "";
        /// <summary>
        /// The SeatID for the Selected Passenger
        /// </summary>
        public string SelectedPassengerSeatID
        {
            get
            {
                return _selectedPassengerSeatID;  
            }
            set
            {
                SetProperty(ref _selectedPassengerSeatID, value);
            }
        }

        private Passenger _selectedPassenger;
        /// <summary>
        /// The currently selected Passenger
        /// </summary>
        public Passenger SelectedPassenger
        {
            get
            {
                return _selectedPassenger;
            }
            set
            {
                SetProperty(ref _selectedPassenger, value);
                SelectedPassengerSeatID = SelectedAircraft.GetPassengerSeatID(SelectedPassenger);
            }
        }

        private int _selectedSeatID;
        /// <summary>
        /// The currently selected seat
        /// </summary>
        public int SelectedSeatID
        {
            get
            {
                return _selectedSeatID;
            }
            set
            {
                SetProperty(ref _selectedSeatID, value);
            }
        }

        private Aircraft _selectedAircraft;
        /// <summary>
        /// The currently selected Aircraft
        /// </summary>
        public Aircraft SelectedAircraft
        {
            get => _selectedAircraft;
            set
            {
                if (SetProperty(ref _selectedAircraft, value))
                {
                    SeatingGridViewModel.Aircraft = _selectedAircraft;
                    Passengers = _selectedAircraft.Passengers;
                }
            }
        }

        private IEnumerable<Passenger> _passengers;
        /// <summary>
        /// All of the passengers on to be displayed
        /// </summary>
        public IEnumerable<Passenger> Passengers
        {
            get
            {
                if (_passengers == null)
                    return Enumerable.Empty<Passenger>();
                return _passengers;
            }
            set
            {
                SetProperty(ref _passengers, value);
            }
        }

        /// <summary>
        /// View Model empty constructor
        /// </summary>
        public MainWindowViewModel()
        {
            Aircraft = new List<Aircraft>();
            SeatingGridViewModel = new SeatingGridViewModel();

            LoadFlights();
        }

        /// <summary>
        /// Function to load flights sence the total seats on a flight are undefined this will assign them to an arbtrary random value
        /// </summary>
        public void LoadFlights()
        {
            Random rand = new Random();
        
            foreach (Flight flight in Controllers.FlightController.GetAllFlights())
            {
                int seats = 1;
                do
                {
                    seats = rand.Next(12, 25);
                } while (seats % 4 != 0);
                
                Aircraft aircraft = new Aircraft(flight, seats, 4, 1);
                Aircraft.Add(aircraft);
            }
        }
    }
}
