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
        public void TwoPlusThreeIsFive()
        {
            int total = _calc.AddNumbers("2 + 3");
            Assert.AreEqual(5 , total);
        }

        [Test]
        public void SubtractionIsRecognised()
        {
            bool isRecognisedAsSubtraction = _calc.InputIsSubtraction("5 - 3");
            Assert.That(isRecognisedAsSubtraction, Is.True);
        }

        [Test]
        public void FiveMinusThreeIsTwo()
        {
            int total = _calc.SubtractNumbers("5 - 3");
            Assert.AreEqual(2, total);
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
            int total = _calc.MultiplyNumbers("2 x 3");
            Assert.AreEqual(6, total);
        }

        [Test]
        public void DivisionIsRecognised()
        {
            bool isRecognisedAsDivision = _calc.InputIsDivision("6 / 3");
            Assert.That(isRecognisedAsDivision, Is.True);
        }

        [Test]
        public void SixDivideThree()
        {
            int total = _calc.DivideNumbers("6 / 3");
            Assert.AreEqual(2, total);
        }

        [Test]
        public void BraketsAreHandledFirst()
        {
            ICollection<string> bracketsList = _calc.IsolateBodmasBrakets("3 + [3 * 2]");
            string firstBraketContent = bracketsList.First();
            int result = _calc.GetResultFromSingleStringCalculation(firstBraketContent);
            Assert.AreEqual(9, result);

        } 
     

     
    }
}
