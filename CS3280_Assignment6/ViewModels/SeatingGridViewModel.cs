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

        public string AircraftTaleNumber
        {
            get => Aircraft.TaleNumber;
        }
    }
}
