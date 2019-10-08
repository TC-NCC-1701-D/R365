using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [TestMethod]
        public void TestSumNumbersCase1B()
        {
            long expected = 5001;
            string delimeterInputData = ",";
            string numberInputData = "1,5000";
            
            string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
            long total = strCalc.SumNumbers(numberInputData, delimeters);

            Assert.AreEqual(expected, total);
        }

        [TestMethod]
        public void TestSumNumbersCase1C()
        {
            long expected = 1;
            string delimeterInputData = ",";
            string numberInputData = "4,-3";
            
            string[] delimeters = strCalc.GetDeleimeters(delimeterInputData);
            long total = strCalc.SumNumbers(numberInputData, delimeters);

            Assert.AreEqual(expected, total);
        }

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
    }
}
