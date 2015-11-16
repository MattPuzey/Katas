using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
       static void Main(string[] args)
       {
           Calculator _calc = new Calculator();
           string userInput= ""; 
            
           while (userInput != "exit")
            {
                Console.WriteLine("Enter a calculation below, you can use [] for bodmas e.g. [3 + 5] x 2");

                userInput = Console.ReadLine();
                double result;
                if (_calc.ContainsBrackets(userInput))
                {
                    var opertionWithBracketsCalculated = _calc.BracketIsolationCalculation(userInput);
                    result = _calc.GetResultFromSingleCalculation(opertionWithBracketsCalculated);
                } else {
                    result = _calc.GetResultFromSingleCalculation(userInput);
                }
                Console.WriteLine(result); 
                //Console.WriteLine("Press enter to clear");
                //Console.Read();
                //Console.Clear();
            }
           
       }
    }
}