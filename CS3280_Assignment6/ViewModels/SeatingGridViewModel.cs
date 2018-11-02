using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3280_Assignment6.Models;

namespace CS3280_Assignment6.ViewModels
{
    public class SeatingGridViewModel
    {
        public Aircraft Aircraft { get; set; } = null;

        public SeatingGridViewModel(Aircraft aircraft)
        {
            Aircraft = aircraft;
        }
    }
}
