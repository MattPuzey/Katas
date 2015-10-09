using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    class Program
    {
        // Invalid score input not handled

        static void Main(string[] args)
        {
            int Score = 0;
            
            Console.WriteLine("Enter bowling score in the format: X|X|X|X|X|X|X|X|X|X||XX");
            Console.WriteLine("or ...X|7/|9-|X|-8|8/|-6|X|X|X||81");
            Console.WriteLine("etc.");
            Console.WriteLine("X indicates a strike, / indicates a spare, - indicates a miss, | indicates a frame boundary");
            var userInput = Console.ReadLine();

            int extraScoreRollsLeft = 0;
            int lastRollScore = 0;

            foreach (char character in userInput)
            {
                
                var c = character.ToString();
                int frameScore = 0;
                int n;
                bool isNumeric = int.TryParse(c, out n);

                if (c == "X" )
                {
                    frameScore = 10;
                    Score = Score + frameScore;
                    extraScoreRollsLeft = extraScoreRollsLeft + 2;
                        
                }
                else if (c == "/")
                {
                    frameScore = 10;
                    Score = Score - lastRollScore + 10;
                    extraScoreRollsLeft = extraScoreRollsLeft + 1;
                }
                //Check for integer
                else if (isNumeric)
                {
                    frameScore = n;
                    Score = Score + frameScore;
                }

                if (extraScoreRollsLeft > 0)
                {
                    // Add roll score on once more for extra points
                    extraScoreRollsLeft = extraScoreRollsLeft - 1;
                    Score = Score + frameScore;
                    
                }
                Console.WriteLine(Score);
                Console.WriteLine("There are  " + extraScoreRollsLeft + "   Double score rolls left");
                lastRollScore = frameScore;
            }
            Console.WriteLine("The Score is: " + Score);
            Console.ReadLine();
        }
    }
}
