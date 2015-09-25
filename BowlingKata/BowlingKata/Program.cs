using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using BowlingKata;


namespace BowlingKata
{
    public class Game
    {
        public int finalScore { get; set; }

       

        public static void Main()
        {
            List<Frame> _frames = new List<Frame>();
            
            foreach (Frame f in _frames)
            {
                
                f.calculateFrameScore(f.score, f.lastFrameWasSpare, f.lastFrameWasStrike);
                Console.WriteLine(f.score);
                finalScore = f.score;
            }


            Console.WriteLine(finalScore);
        }
        public class CurrentFrame : Frame
        {
             
        }
        

    }

}
