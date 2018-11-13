using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Utilities
{
    /// <summary>
    /// The value of the Operation result
    /// </summary>
    public enum OperationResultValue
    {
        Success,
        Failure
    }

    /// <summary>
    /// Result of an operation
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Messages
        /// </summary>
        public List<string> Messages { get; private set; } = new List<string>();
        /// <summary>
        /// Result
        /// </summary>
        public OperationResultValue Result { get; set; }

        /// <summary>
        /// Add a message
        /// </summary>
        /// <param name="message"></param>
        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
}
