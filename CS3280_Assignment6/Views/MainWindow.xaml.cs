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

namespace CS3280_Assignment6.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            SeatingGrid.SeatingGridViewModel = new ViewModels.SeatingGridViewModel(new Models.Aircraft
            {
                ID = 0,
                TaleNumber = "747",
                TotalSeats = 12,
                Columns = 4,
                Aisles = 1
            });
            SeatingGrid.UpdateView();
        }
    }
}
