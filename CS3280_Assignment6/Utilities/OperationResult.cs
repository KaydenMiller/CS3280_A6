using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Utilities
{
    public enum OperationResultValue
    {
        Success,
        Failure
    }

    public class OperationResult
    {
        public List<string> Messages { get; private set; }
        public OperationResultValue Result { get; set; }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
}
