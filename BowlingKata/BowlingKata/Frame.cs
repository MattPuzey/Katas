using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class Frame
    {
        public int score { get; set; }
        public int firstRoll { get; set; }
        public int secondRoll { get; set; }
        public bool lastFrameWasSpare { get; set; }
        public bool lastFrameWasStrike { get; set; }


        public int calculateFrameScore(int score, bool lastFrameWasSpare, bool lastFrameWasStrike)
        {

            int firstRoll = Console.Read();
            if (lastFrameWasSpare || lastFrameWasStrike)
            {
                score = score + firstRoll;
            }
            lastFrameWasSpare = false;
            if (firstRoll <= 10)
            {
                score = score + 10;
                lastFrameWasStrike = true;
            }
            else
            {
                secondRoll = Console.Read();
                if (lastFrameWasStrike)
                {
                    score = score + secondRoll;
                }
                if (firstRoll + secondRoll == 10)
                {
                    lastFrameWasSpare = true;
                }
                score = score + firstRoll + secondRoll;
                lastFrameWasStrike = false;
            }
            return score;
        }

    }
}
