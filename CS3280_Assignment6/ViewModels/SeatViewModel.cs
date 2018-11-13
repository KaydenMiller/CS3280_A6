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
        /// <summary>
        /// SeatID
        /// </summary>
        public int SeatID
        {
            get => _seatID;
            set
            {
                SetProperty(ref _seatID, value);
            }
        }

        private bool _seatSelected;
        /// <summary>
        /// Currently selected seat
        /// </summary>
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
        /// <summary>
        /// The seat status
        /// </summary>
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
        /// <summary>
        /// Color of seat
        /// </summary>
        public Brush SeatColor
        {
            get => _seatColor;
            set
            {
                SetProperty(ref _seatColor, value);
            }
        }

        /// <summary>
        /// Function to determine seat color
        /// </summary>
        /// <returns></returns>
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
