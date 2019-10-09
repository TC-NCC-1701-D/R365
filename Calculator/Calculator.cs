using System;

namespace Calculator
{
    /// <summary>
    /// Written By: Tahmid Choudhuri
    /// Restaurant365 Code Challenge - String Calculator
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Addition Calculator Method
        /// </summary>
        /// <param name="numberInputData">string user data</param>
        /// <param name="delimeters">array of delemeters</param>
        /// <returns></returns>
        public long SumNumbers(string numberInputData, string[] delimeters)
        {

            var items = numberInputData.Split(delimeters, StringSplitOptions.None);

            if (items.Length <= 0)
                return 0;

            //int maxItems = 2;
            //if (items.Length > maxItems)
            //{
            //    throw new MoreThanTwoNumberException("Numbers cannot be more than 2");
            //}


            string negNumbers = ValidateNegativeNumbers(items);
            if (negNumbers.Length > 0)
            {
                throw new InvalidNegativeNumberException(string.Format("Negative numbers are not allowed: {0}", negNumbers));
            }

            long result = 0;
            foreach (var num in items)
            {
                long data = 0;
                bool isNum = long.TryParse(num, out data);
                if (isNum)
                    result += data;
            }
            return result;

        }

        /// <summary>
        /// Converts a single delemeter to string[]
        /// </summary>
        /// <param name="delimeterInputData"></param>
        /// <returns></returns>
        public string[] GetDeleimeters(string delimeterInputData)
        {
            return delimeterInputData.Split('@');
        }


        public string ValidateNegativeNumbers(string[] items)
        {
            string negDatas = "";
            foreach (var num in items)
            {
                long data = 0;
                bool isNum = long.TryParse(num, out data);
                if (isNum && data < 0)
                    negDatas += data.ToString() + " ";
            }
            return negDatas.Trim();
        }

    }
}
