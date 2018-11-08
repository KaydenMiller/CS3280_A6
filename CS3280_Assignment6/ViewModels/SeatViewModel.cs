using CS3280_Assignment6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Drawing;

namespace CS3280_Assignment6.ViewModels
{
    public class SeatViewModel : ViewModelBase
    {
        private int _seatID;
        public int SeatID
        {
            get => _seatID;
            set
            {
                SetProperty(ref _seatID, value);
            }
        }

        private bool _seatSelected;
        public bool SeatSelected
        {
            get => _seatSelected;
            set
            {
                SetProperty(ref _seatSelected, value);
                SeatColor = DetermineSeatColor();
            }
        }

        private SeatStatus _seatStatus;
        public SeatStatus SeatStatus
        {
            get => _seatStatus;
            set
            {
                SetProperty(ref _seatStatus, value);
                SeatColor = DetermineSeatColor();
            }
        }

        private Brush _seatColor;
        public Brush SeatColor
        {
            get => _seatColor;
            set
            {
                SetProperty(ref _seatColor, value);
            }
        }

        private Brush DetermineSeatColor()
        {
            Color color = Colors.Black;

            if (!SeatSelected)
            {
               switch (_seatStatus)
               {
                case SeatStatus.Empty:
                    color = Colors.Blue;
                    break;
                case SeatStatus.Taken:
                    color = Colors.Red;
                    break;
               }
            }
            else
            {
                color = Colors.Green;
            }            

            return new SolidColorBrush(color);
        }
    }
}
