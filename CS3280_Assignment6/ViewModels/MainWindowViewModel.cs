using CS3280_Assignment6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public List<Aircraft> Aircraft { get; set; } 
        public SeatingGridViewModel SeatingGridViewModel { get; set; }

        private string _selectedPassengerSeatID = "";
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

        public MainWindowViewModel()
        {
            Aircraft = new List<Aircraft>();
            SeatingGridViewModel = new SeatingGridViewModel();

            LoadFlights();
        }

        public void LoadFlights()
        {
            foreach (Flight flight in Controllers.FlightController.GetAllFlights())
            {
                Aircraft aircraft = new Aircraft(flight, 12, 4, 1);
                Aircraft.Add(aircraft);
            }
        }
    }
}
