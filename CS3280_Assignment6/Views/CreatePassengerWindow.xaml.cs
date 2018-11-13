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
using System.Windows.Shapes;

namespace CS3280_Assignment6.Views
{
    /// <summary>
    /// Interaction logic for CreatePassengerWindow.xaml
    /// </summary>
    public partial class CreatePassengerWindow : Window
    {
        /// <summary>
        /// Constructor for Passenger window
        /// </summary>
        public CreatePassengerWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cancel Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// On window loaded event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FirstName.Focus();
        }
    }
}
