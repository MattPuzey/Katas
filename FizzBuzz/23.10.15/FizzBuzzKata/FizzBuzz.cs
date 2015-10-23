using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzKata
{
    internal class FizzBuzz
    {
        public bool IsDivisisbleByThree(int input)
        {
            return (input%3) == 0;
        }

        public bool IsDivisisbleByFive(int input)
        {
            return (input%5) == 0;
        }

        public string GetTextForNumber(int input)
        {
            if (IsDivisisbleByThree(input) & IsDivisisbleByFive(input))
            {
                return "FizzBuzz";
            }
            if (IsDivisisbleByFive(input))
            {
                return "Buzz";
            }
            if (IsDivisisbleByThree(input))
            {
                return "Fizz";
            }
            else
            {
               return input.ToString();
            }
        }

        public string DoTheWholeThing(int rangeMaximum)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= rangeMaximum; ++i)
            {
                sb.AppendFormat("{0} ", GetTextForNumber(i));
            }
            return sb.ToString();
        }
    }
}
