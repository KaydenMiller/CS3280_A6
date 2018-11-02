using CS3280_Assignment6.Utilities;
using CS3280_Assignment6.ViewModels;
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
    /// Interaction logic for SeatingGrid.xaml
    /// </summary>
    public partial class SeatingGrid : UserControl
    {
        public SeatingGridViewModel SeatingGridViewModel { get; set; }

        public SeatingGrid()
        {
            InitializeComponent();
        }

        public SeatingGrid(SeatingGridViewModel seatingGridViewModel)
        {
            InitializeComponent();

            SeatingGridViewModel = seatingGridViewModel;
        }

        private OperationResult GenerateView()
        {
            OperationResult operationResult = new OperationResult();

            if (SeatingGridViewModel == null)
            {
                operationResult.Result = OperationResultValue.Failure;
                operationResult.Messages.Add("Empty Seating Grid View Model.");
                return operationResult;
            }

            GenerateColumns(SeatingGridViewModel.Aircraft.Columns, SeatingGridViewModel.Aircraft.Aisles);
            GenerateSeats(SeatingGridViewModel.Aircraft.Columns);

            operationResult.Result = OperationResultValue.Success;
            return operationResult;
        }

        private void GenerateSeats(int cols)
        {
            for (int column = 0; column < cols; column++)
            {
                Seat seat = new Seat();
                
            }
        }

        private void GenerateColumns(int cols, int aisles)
        {
            for (int column = 0; column < cols + aisles; column++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                GridLength gridLength;

                if ((cols / 2) + 1 == column)
                {
                    gridLength = new GridLength(1, GridUnitType.Star);
                }
                else
                {
                    gridLength = new GridLength(1, GridUnitType.Auto);
                }

                colDef.Width = gridLength;
                SeatingLayoutGrid.ColumnDefinitions.Add(colDef);
            }
        }
    }
}
