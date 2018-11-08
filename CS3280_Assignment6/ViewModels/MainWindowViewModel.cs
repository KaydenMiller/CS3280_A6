using CS3280_Assignment6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.ViewModels
{
    public class MainWindowViewModel
    {
        public List<Aircraft> Aircraft { get; set; } = new List<Aircraft>();
        public SeatingGridViewModel SeatingGridViewModel { get; set; } = new SeatingGridViewModel();
    }
}
