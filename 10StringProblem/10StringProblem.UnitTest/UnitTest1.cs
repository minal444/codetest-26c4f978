using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _10StringProblem;
using _10StringProblem.BusinessLogic;

namespace _10StringProblem.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateInputNumber()
        {
            string inputArraay = "12345";
            bool expectedResult = true;
            bool actualResult = Program.ValidateInput(inputArraay);
            Assert.AreEqual<bool>(expectedResult, actualResult);

        }

        [TestMethod]
        public void ValidateInputString()
        {
            string inputArraay = "ABC";
            bool expectedResult = false;
            bool actualResult = Program.ValidateInput(inputArraay);
            Assert.AreEqual<bool>(expectedResult, actualResult);

        }

        [TestMethod]
        public void ValidateFriendlyNumber_Sucess()
        {
            Int64 inputNumber = 3523014;
            bool expectedResult = true;
            AlgoHelper algo = new AlgoHelper();
            bool actualResult = algo.ValidateFriendlyNess(inputNumber);
            Assert.AreEqual<bool>(expectedResult, actualResult);

        }
        [TestMethod]
        public void ValidateFriendlyNumber_Failuer()
        {
            Int64 inputNumber = 28546;
            bool expectedResult = false;
            AlgoHelper algo = new AlgoHelper();
            bool actualResult = algo.ValidateFriendlyNess(inputNumber);
            Assert.AreEqual<bool>(expectedResult, actualResult);

        }
        [TestMethod]
        public void ValidateFriendlyNumber_RendomTest()
        {
            Int64 inputNumber = 190;
            bool expectedResult = true;
            AlgoHelper algo = new AlgoHelper();
            bool actualResult = algo.ValidateFriendlyNess(inputNumber);
            Assert.AreEqual<bool>(expectedResult, actualResult);

        }
    }
}
