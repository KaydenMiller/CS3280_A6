using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3280_Assignment6.Models;

namespace CS3280_Assignment6.ViewModels
{
    public class SeatingGridViewModel : ViewModelBase
    {
        private Aircraft _aircraft;
        public Aircraft Aircraft
        {
            get => _aircraft;
            set => SetProperty(ref _aircraft, value);
        }

        public string Aircraft_Flight_ID
        {
            get => Aircraft.Flight_ID.ToString();
        }

        public string Aircraft_Flight_Number
        {
            get => Aircraft.Flight_Number.ToString();
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
    }
}
