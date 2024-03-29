﻿using System;

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
                { // only add numbers < 1000 rule # 5
                    if (data <= 1000) 
                        result += data;
                    else
                        result += 0;
                }
            }
            return result;

        }

        /// <summary>
        /// Converts a single delemeter to string[]. It also checks if user sent deleimeter definations in the input string
        /// , if yes then it parses them.
        /// </summary>
        /// <param name="delimeterInputData"></param>
        /// <returns></returns>
        public string[] GetDeleimeters(string delimeterInputData)
        {
            string result = delimeterInputData;

            if (delimeterInputData.Contains("//"))
            {
                result = delimeterInputData
                                    .Replace("//", "")
                                    .Replace("\\", "")
                                    .Replace("][", "@")
                                    .Replace("[", "")
                                    .Replace("]", "");
            }


            return result.Split('@');
        }

        /// <summary>
        /// Validate negative inputs and return a string containing negative input data
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
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

        /// <summary>
        /// /This method parses delimeter definations and input test data
        /// </summary>
        /// <param name="delimeterInputData">return delemeters </param>
        /// <param name="numberInputData">return test data for calc</param>
        public void ParseInputData(ref string delimeterInputData, ref string numberInputData)
        {
            // check to see if user is passing deleimeter defination format markers
            if (numberInputData.Contains("//"))
            {
                string[] result = numberInputData.Split('n');
                if (result.Length > 1)
                {
                    delimeterInputData = result[0];
                    numberInputData = result[1];
                }
            }
        }

    }
}
