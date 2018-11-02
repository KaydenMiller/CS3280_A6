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
    /// Interaction logic for Seat.xaml
    /// </summary>
    public partial class SeatControl : UserControl
    {
        private Models.Seat _seat { get; set; }
        public Models.Seat Seat
        {
            get { return _seat; }
            set
            {
                _seat = value;
                ConfigureSeat();
            }
        }

        public SeatControl()
        {
            InitializeComponent();
        }

        private void ConfigureSeat()
        {
            // Set the seat color resource
            switch (_seat.Status)
            {
                case Models.SeatStatus.Empty:
                    InnerGrid.Style = Resources["Seat_Empty"] as Style;
                    break;
                case Models.SeatStatus.Selected:
                    InnerGrid.Style = Resources["Seat_Selected"] as Style;
                    break;
                case Models.SeatStatus.Taken:
                    InnerGrid.Style = Resources["Seat_Taken"] as Style;
                    break;
            }

            // Set the ID of the seat
            ID.Text = (_seat.ID + 1).ToString();
        }
    }
}
