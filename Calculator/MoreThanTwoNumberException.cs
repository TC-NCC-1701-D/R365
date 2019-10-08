using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    /// <summary>
    /// Exception for more than two data
    /// </summary>
    [Serializable]
    public class MoreThanTwoNumberException : Exception
    {
        public MoreThanTwoNumberException(string message) : base(message)
        {

        }
    }
}
