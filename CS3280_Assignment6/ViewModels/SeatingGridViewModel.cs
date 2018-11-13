using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3280_Assignment6.Models;

namespace CS3280_Assignment6.ViewModels
{
    /// <summary>
    /// Seating grid view model
    /// </summary>
    public class SeatingGridViewModel : ViewModelBase
    { 
        private Aircraft _aircraft;
        /// <summary>
        /// Aircraft
        /// </summary>
        public Aircraft Aircraft
        {
            get => _aircraft;
            set => SetProperty(ref _aircraft, value);
        }

        /// <summary>
        /// The aircrafts flight ID
        /// </summary>
        public string Aircraft_Flight_ID
        {
            get => Aircraft.Flight_ID.ToString();
        }

        /// <summary>
        /// The aircrafts flight number
        /// </summary>
        public string Aircraft_Flight_Number
        {
            get => Aircraft.Flight_Number.ToString();
        }

        private int _selectedSeatID;
        /// <summary>
        /// The currently selected seat on the flight
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
    }
}
