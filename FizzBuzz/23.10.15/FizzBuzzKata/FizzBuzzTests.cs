using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FizzBuzzKata
{
    [TestFixture]
    internal class FizzBuzzTets
    {
        private FizzBuzz fb = new FizzBuzz();

        [Test]
        public void ThreeIsDivisibleByThreeTest()
        {
            bool divisible = fb.IsDivisisbleByThree(3);

            Assert.That(divisible, Is.True);
        }

        [Test]
        public void FiveIsDivisibleByFiveTest()
        {
            bool divisible = fb.IsDivisisbleByFive(5);

            Assert.That(divisible, Is.True);
        }

        [Test]
        public void TextForDivisibleByThreeIsFizzTest()
        {
            string text = fb.GetTextForNumber(3);

            Assert.That(text, Is.EqualTo("Fizz"));
        }

        [Test]
        public void TextForDivisibleByFiveIsBuzzTest()
        {
            string text = fb.GetTextForNumber(5);

            Assert.That(text, Is.EqualTo("Buzz"));
        }

        [Test]
        public void TextForDivisbleByThreeAndFiveIsFizzBuzz()
        {
            string text = fb.GetTextForNumber(15);

            Assert.That(text, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void TextForNotDivisibleByThreeOrFiveIsNumber()
        {
            string text = fb.GetTextForNumber(4);

            Assert.That(text, Is.EqualTo("4"));
        }

        [Test]
        public void CanDoTheWholeThingTest()
        {
            string allOfIt = fb.DoTheWholeThing(15);

            Assert.That(
                allOfIt, 
                Is.EqualTo("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz "));
        }
    }
}
