using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator
{
    [TestFixture]
    internal class CalculatorTests
    {
        private Calculator _calc = new Calculator();

        [Test]
        public void AdditionIsRecognised()
        {
            bool isRecognisedAsAddition = _calc.InputIsAddtion("2 + 3");
            Assert.That(isRecognisedAsAddition, Is.True);
        }

        [Test]
        public void TwoPlusThreePlusThreeIsEight()
        {
            double result = _calc.AddNumbers("2 + 3 + 3");
            Assert.AreEqual(8, result);
        }

        [Test]
        public void SubtractionIsRecognised()
        {
            bool isRecognisedAsSubtraction = _calc.InputIsSubtraction("5 - 3");
            Assert.That(isRecognisedAsSubtraction, Is.True);
        }

        [Test]
        public void FiveMinusThreeMinusThreeIsMinusFour()
        {
            double result = _calc.SubtractNumbers("5 - 3 - 4");
            Assert.AreEqual(-2, result);
        }

        [Test]
        public void MultiplicationIsRecognised()
        {
            bool isRecognisedAsMultiplication = _calc.InputIsMultiplication("2 x 3");
            Assert.That(isRecognisedAsMultiplication, Is.True);
        }


        [Test]
        public void TwoTimesThreeIsSix()
        {
            double result = _calc.MultiplyNumbers("2 x 3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void DivisionIsRecognised()
        {
            bool isRecognisedAsDivision = _calc.InputIsDivision("6 / 3");
            Assert.That(isRecognisedAsDivision, Is.True);
        }

        [Test]
        public void SixteenDivideFourDivideTwoIsTwo()
        {
            double result = _calc.DivideNumbers("16 / 4 / 2");
            Assert.AreEqual(2, result);
        }

        [Test]
        public void PowersAreRecognised()
        {
            bool isRecognisedAsPowers = _calc.InputIsPower("2 ^ 3");
            Assert.That(isRecognisedAsPowers, Is.True);
        }

        [Test]
        public void PowersAreCalculated()
        {
            double result = _calc.CalculatePower("2 ^ 3 ^ 2");
            Assert.AreEqual(64, result);
        }

        [Test]
        public void BraketsAreIsolated()
        {
            ICollection<string> bracketCalculations = _calc.ExtractBodmasBrakets("3 + [3 x 2] - [3 / 4]");
            Assert.That(bracketCalculations.Last() == "3 / 4", Is.True);
        }

        [Test]
        public void SingleOperatorStringInputIsInspectedThenCalculated()
        {
            double result1 = _calc.GetResultFromSingleCalculation("3 x 4");
            Assert.AreEqual(12, result1);

            double result2 = _calc.GetResultFromSingleCalculation("12 / 4");
            Assert.AreEqual(3, result2);
        }

        [Test]
        public void BracketCalculationsAreHandledFirstThenFedBackIntoString()
        {
            string result = _calc.BracketIsolationCalculation("3 + [3 x 2] - [4 + 5]");
            StringAssert.AreEqualIgnoringCase("3 + 6 - 9", result);
        }

        [Test]
        public void UseBodmasToGroupMixedOperatorCalculations()
        {
            string result = _calc.GroupCalculationsWithBodmasBrackets("3 x 4 + 2 - 4");
            StringAssert.AreEqualIgnoringCase("[[3 x 4] + 2] - 1", result);
        }
     

     
    }
}
