using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;


namespace Calculator
{
    internal class Calculator
    {
        public bool InputIsAddtion(string input)
        {
            if (input.Contains("+"))
            {
                return true;
            }
            return false;
        }

        public int AddNumbers(string input)
        {
            input  = input.Trim();
            if (!string.IsNullOrEmpty(input) && InputIsAddtion(input))
            {
                string[] digitsStrings = input.Split('+');
                int total = 0;
                foreach (string digitsString in digitsStrings)
                {
                    int i = int.Parse(digitsString);
                    total += i;
                }
                return total;
            }
           
            return 0;
        }

        public bool InputIsSubtraction(string input)
        {
            if (input.Contains("-"))
            {
                return true;
            }
            return false;
        }

        public int SubtractNumbers(string input)
        {
            input = input.Trim();
            if (!string.IsNullOrEmpty(input) && InputIsSubtraction(input))
            {
                string[] digitsStrings = input.Split('-');
                string firstDigit = digitsStrings[0];
                string SecondDigit = digitsStrings[1];
                int total = int.Parse(firstDigit) - int.Parse(SecondDigit);
                if (digitsStrings.Length > 2)
                {
                    var digitList = new List<string>(digitsStrings);
                    digitList.RemoveAt(0);
                    digitList.RemoveAt(1);
                    int additionalSubtraction = 0 ; 
                    foreach (string digit in digitList)
                    {

                        int i = int.Parse(digit);
                        additionalSubtraction = total - i;
                    }
                    total = total - additionalSubtraction;
                }
                
                return total;
            }
            return 0;
        }

        public bool InputIsMultiplication(string input)
        {
            if (input.Contains("x"))
            {
                return true;
            }
            return false;
        }

        public int MultiplyNumbers(string input)
        {
            input = input.Trim();
            if (!string.IsNullOrEmpty(input) && InputIsMultiplication(input))
            {
                string[] digitsStrings = input.Split('x');
                string firstDigit = digitsStrings[0];
                string SecondDigit = digitsStrings[1];
                int total = int.Parse(firstDigit) * int.Parse(SecondDigit);
                if (digitsStrings.Length > 2)
                {
                    var digitList = new List<string>(digitsStrings);
                    digitList.RemoveAt(0);
                    digitList.RemoveAt(1);
                    int additionalMultiplication = 1;
                    foreach (string digit in digitList)
                    {

                        int i = int.Parse(digit);
                        additionalMultiplication = additionalMultiplication * i;
                    }
                    total = total * additionalMultiplication;
                }

                return total;
            }
            return 0;
        }

        public bool InputIsDivision(string input)
        {
            if (input.Contains("/"))
            {
                return true;
            }
            return false;
        }

        public int DivideNumbers(string input)
        {
            input = input.Trim();
            if (!string.IsNullOrEmpty(input) && InputIsDivision(input))
            {
                string[] digitsStrings = input.Split('/');
                string firstDigit = digitsStrings[0];
                string SecondDigit = digitsStrings[1];
                int total = int.Parse(firstDigit) / int.Parse(SecondDigit);
                if (digitsStrings.Length > 2)
                {
                    var digitList = new List<string>(digitsStrings);
                    digitList.RemoveAt(0);
                    digitList.RemoveAt(1);
                    int additionalDivision = 1;
                    foreach (string digit in digitList)
                    {

                        int i = int.Parse(digit);
                        additionalDivision = additionalDivision / i;
                    }
                    total = total * additionalDivision;
                }

                return total;
            }
            return 0;
        }

        public ICollection<string> IsolateBodmasBrakets(string input)
        {
            input = input.Trim();
            if (input.Contains("[") & input.Contains("]"))
            {
                ICollection<string> braketcalculations =
                 Regex.Matches(input.Replace(Environment.NewLine, ""), @"\[([^]]*)\]")
                     .Cast<Match>()
                     .Select(x => x.Groups[1].Value)
                     .ToList();
                return braketcalculations;
            }
            List<string> emptyCollection = new  List<string>();
            return emptyCollection;
        }

        public int GetResultFromSingleStringCalculation(string input)
        {
                int calculationResult = 0;
                if (InputIsAddtion(input))
                    calculationResult = AddNumbers(input);
                else if (InputIsSubtraction(input))
                    calculationResult = SubtractNumbers(input);
                else if (InputIsMultiplication(input))
                    calculationResult = MultiplyNumbers(input);
                else if (InputIsDivision(input))
                    calculationResult = DivideNumbers(input);
            return calculationResult;
        }

        public ICollection<int> BracketIsolationCalculation(string input)
        {
            ICollection<string> bracketCalcualtions = IsolateBodmasBrakets(input);
            ICollection<int> integerResults = new List<int>();
            foreach (var bracketCalculation in bracketCalcualtions)
            {
                int result = GetResultFromSingleStringCalculation(bracketCalculation);
                integerResults.Add(result);
            }
            return integerResults;
        }
    }
}
