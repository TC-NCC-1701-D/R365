using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestCalculator
{
    /// <summary>
    /// Test Cases are based on Requirement list.
    /// Each req item is defined as Case#[1...8]
    /// Each requirement sub test are defined as Case#[1...8][A....Z]
    /// </summary>

    [TestClass]
    public class UnitTestCalculator
    {
        Calculator.Calculator strCalc;

        public UnitTestCalculator()
        {
            strCalc = new Calculator.Calculator();
        }

        // REQ CASE #1 -------------------------------------

        [TestMethod]
        public void TestSumNumbersCase1A()
        {
            long expected = 20;
            string delimeterInputData = ",";
            string numberInputData = "20";
            
            string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
            long total = strCalc.SumNumbers(numberInputData, delimeters);

            Assert.AreEqual(expected, total);
        }

        // Rule # 5 does not allow numbers > 1000
        //[TestMethod]
        //public void TestSumNumbersCase1B()
        //{
        //    long expected = 5001;
        //    string delimeterInputData = ",";
        //    string numberInputData = "1,5000";

        //    string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
        //    long total = strCalc.SumNumbers(numberInputData, delimeters);

        //    Assert.AreEqual(expected, total);
        //}



        // Rule # 4 does not allow negative numbers
        //[TestMethod]
        //public void TestSumNumbersCase1C()
        //{
        //    long expected = 1;
        //    string delimeterInputData = ",";
        //    string numberInputData = "4,-3";

        //    string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
        //    long total = strCalc.SumNumbers(numberInputData, delimeters);

        //    Assert.AreEqual(expected, total);
        //}

        [TestMethod]
        public void TestSumNumbersCase1D()
        {
            long expected = 4;
            string delimeterInputData = ",";
            string numberInputData = "4,";
           
            string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
            long total = strCalc.SumNumbers(numberInputData, delimeters);

            Assert.AreEqual(expected, total);
        }

        [TestMethod]
        public void TestSumNumbersCase1E()
        {
            long expected = 5;
            string delimeterInputData = ",";
            string numberInputData = "5,tytyt";
            
            string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
            long total = strCalc.SumNumbers(numberInputData, delimeters);

            Assert.AreEqual(expected, total);
        }

        // As per req two limit has been removed 

        //[TestMethod]
        //public void TestSumNumbersCase1F()
        //{
        //    // validate exception for more than two params
        //    string expected = "Numbers cannot be more than 2";
        //    string result = "";
        //    string delimeterInputData = ",";
        //    string numberInputData = "5,2,1";

        //    string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
        //    try
        //    {
        //        long total = strCalc.SumNumbers(numberInputData, delimeters);
        //    }
        //    catch(Calculator.MoreThanTwoNumberException e)
        //    {
        //        result = e.Message;
        //    }
        //    Assert.AreEqual(expected, result);
        //}

        // REQ CASE #2 -------------------------------------

        [TestMethod]
        public void TestSumNumbersCase2()
        {
            long expected = 78;
            string delimeterInputData = ",";
            string numberInputData = "1,2,3,4,5,6,7,8,9,10,11,12";

            string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
            long total = strCalc.SumNumbers(numberInputData, delimeters);

            Assert.AreEqual(expected, total);
        }


        // REQ CASE #3 -------------------------------------

        [TestMethod]
        public void TestSumNumbersCase3()
        {
            long expected = 6;
            string delimeterInputData = ",@\\n";
            string numberInputData = "1\\n2,3"; // since we are not typing on the console we have to escape \ with \\

            string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
            long total = strCalc.SumNumbers(numberInputData, delimeters);

            Assert.AreEqual(expected, total);
        }

        // REQ CASE #4 -------------------------------------

        [TestMethod]
        public void TestSumNumbersCase4()
        {
            // validate exception for more than two params
            string expected = string.Format("Negative numbers are not allowed: {0}", -5);
            string result = "";
            string delimeterInputData = ",";
            string numberInputData = "1,-5";

            string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
            try
            {
                long total = strCalc.SumNumbers(numberInputData, delimeters);
            }
            catch (Calculator.InvalidNegativeNumberException e)
            {
                result = e.Message;
            }
            Assert.AreEqual(expected, result);
        }



        // REQ CASE #5 -------------------------------------

        [TestMethod]
        public void TestSumNumbersCase5()
        {
            long expected = 8;
            string delimeterInputData = ",";
            string numberInputData = "2,1001,6";

            string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
            long total = strCalc.SumNumbers(numberInputData, delimeters);

            Assert.AreEqual(expected, total);
        }


        // REQ CASE #6 -------------------------------------

        [TestMethod]
        public void TestSumNumbersCase6()
        {
            long expected = 7;
            string delimeterInputData = ",";
            string numberInputData = "//#\\n2#5";

            strCalc.ParseInputData(ref delimeterInputData, ref numberInputData);
            string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
            long total = strCalc.SumNumbers(numberInputData, delimeters);

            Assert.AreEqual(expected, total);
        }


        // REQ CASE #7 -------------------------------------

        [TestMethod]
        public void TestSumNumbersCase7()
        {
            long expected = 66;
            string delimeterInputData = ",";
            string numberInputData = "//[***]\\n11***22***33";

            strCalc.ParseInputData(ref delimeterInputData, ref numberInputData);
            string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
            long total = strCalc.SumNumbers(numberInputData, delimeters);

            Assert.AreEqual(expected, total);
        }

        // REQ CASE #8 -------------------------------------

        [TestMethod]
        public void TestSumNumbersCase8()
        {
            long expected = 110;
            string delimeterInputData = ",";
            string numberInputData = "//[*][!!][r9r]\\n11r9r22*hh*33!!44";

            strCalc.ParseInputData(ref delimeterInputData, ref numberInputData);
            string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
            long total = strCalc.SumNumbers(numberInputData, delimeters);

            Assert.AreEqual(expected, total);
        }


        // REQ CASE #Stretch Goal Test #1 -------------------------------------

        [TestMethod]
        public void TestSumNumbersCaseStretch1()
        {
            long expected = 12;
            string delimeterInputData = ",";
            string numberInputData = "2,,4,rrrr,1001,6";

            strCalc.ParseInputData(ref delimeterInputData, ref numberInputData);
            string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
            long total = strCalc.SumNumbers(numberInputData, delimeters);

            Assert.AreEqual(expected, total);
        }


    }
}
