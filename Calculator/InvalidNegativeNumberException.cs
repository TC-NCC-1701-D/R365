using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    /// <summary>
    /// Exception for Neg numbers
    /// </summary>
    [Serializable]
    public class InvalidNegativeNumberException : Exception
    {
        public InvalidNegativeNumberException(string message) : base(message)
        {

        }
    }
}
