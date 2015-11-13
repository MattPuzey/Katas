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

        public double AddNumbers(string input)
        {
            input  = input.Trim();
            if (!string.IsNullOrEmpty(input) && InputIsAddtion(input))
            {
                string[] digitsStrings = input.Split('+');
                double total = 0;
                foreach (string digitsString in digitsStrings)
                {
                    double i = double.Parse(digitsString);
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

        public double SubtractNumbers(string input)
        {
            string trimmedInput = input.Replace(" ", "");
;            if (!string.IsNullOrEmpty(trimmedInput) && InputIsSubtraction(trimmedInput))
            {
                string[] digitsStrings = input.Split('-');
                string firstDigit = digitsStrings[0];
                string secondDigit = digitsStrings[1];
                double total = double.Parse(firstDigit) - double.Parse(secondDigit);
                if (digitsStrings.Length > 2)
                {
                    var digitList = new List<string>(digitsStrings);
                    digitList.RemoveAt(0);
                    digitList.RemoveAt(0);
                    foreach (string digit in digitList)
                    {
                        double i = double.Parse(digit);
                        total = total - i;
                    }
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

        public double MultiplyNumbers(string input)
        {
            input = input.Trim();
            if (!string.IsNullOrEmpty(input) && InputIsMultiplication(input))
            {
                string[] digitsStrings = input.Split('x');
                double total = 1;
                var digitList = new List<string>(digitsStrings);
                foreach (string digit in digitList)
                {
                    double i = double.Parse(digit);
                    total = total * i;
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

        public double DivideNumbers(string input)
        {
            input = input.Trim();
            if (!string.IsNullOrEmpty(input) && InputIsDivision(input))
            {
                string[] digitsStrings = input.Split('/');
                string firstDigit = digitsStrings[0];
                string secondDigit = digitsStrings[1];
                double total = double.Parse(firstDigit) / double.Parse(secondDigit);
                if (digitsStrings.Length > 2)
                {
                    var digitList = new List<string>(digitsStrings);
                    digitList.RemoveAt(0);
                    digitList.RemoveAt(0);
                    foreach (string digit in digitList)
                    {
                        double i = double.Parse(digit);
                        total = total / i;
                    }
                }

                return total;
            }
            return 0;
        }

        public bool InputIsPower(string input)
        {
            if (input.Contains("^"))
            {
                return true;
            }
            return false;
        }

        public double CalculatePower(string input)
        {
            input = input.Trim();
            if (!string.IsNullOrEmpty(input) && InputIsPower(input))
            {
                string[] digitsStrings = input.Split('^');
                string firstDigit = digitsStrings[0];
                string secondDigit = digitsStrings[1];
                double total = Math.Pow(double.Parse(firstDigit), double.Parse(secondDigit));
                if (digitsStrings.Length > 2)
                {
                    var digitList = new List<string>(digitsStrings);
                    digitList.RemoveAt(0);
                    digitList.RemoveAt(0);
                    foreach (string digit in digitList)
                    {
                        double i = double.Parse(digit);
                        total = Math.Pow(total, i);
                    }
                }

                return total;
            }
            return 0;
            
        }

        public ICollection<string> ExtractBodmasBrakets(string input)
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
            List<string> emptyCollection = new List<string>();
            return emptyCollection;
        }

        public double GetResultFromSingleCalculation(string input)
        {
                double calculationResult = 0;
            if (InputIsPower(input))
                calculationResult = CalculatePower(input);
                if (InputIsMultiplication(input))
                    calculationResult = MultiplyNumbers(input);
                else if (InputIsDivision(input))
                    calculationResult = DivideNumbers(input);
                else if (InputIsAddtion(input))
                    calculationResult = AddNumbers(input);
                else if (InputIsSubtraction(input))
                    calculationResult = SubtractNumbers(input);
            return calculationResult;
        }

        public string BracketIsolationCalculation(string input)
        {
            ICollection<string> bracketCalcualtions = ExtractBodmasBrakets(input);
            ICollection<double> results = new List<double>();
            foreach (var bracketCalculation in bracketCalcualtions)
            {
                double result = GetResultFromSingleCalculation(bracketCalculation);
                results.Add(result);
            }
            //  TODO:add each result from results back into [] in input and return
            return "";
        }


       
    }
}
