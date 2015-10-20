using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace YatzyKata
{
    
    public enum Categories

    {
        Yatzy = 1 ,
        Pair = 2,
        TwoPairs = 3,
        ThreeOfAKind = 4,
        FourOfAKind = 5, 
        SmallStraight = 6,
        LargeStraight = 7,
        FullHouse = 8
    }

    class Program
    {
        public static int Score { get; set; }

        public static event Action Yatzy;
        public static event Action Pair;
        public static event Action TwoPairs;
        public static event Action ThreeOfAKind;
        public static event Action FourOfAKind;
        public static event Action SmallStraight;
        public static event Action LargeStraight;
        public static event Action FullHouse;


        private static void Main(string[] args)
        {
            Console.WriteLine("Enter the five dice rolls in the form: 3,2,1,4,2");
            var diceRollInput = Console.ReadLine();

            var rolls = diceRollInput.Split(',').Select(Int32.Parse).ToList();

            Console.WriteLine("Give category and score");
            Console.WriteLine("Categories: 1. {0}, 2. {1},  3. {2}, 4. {3}, 5. {4}, 6. {5}, 7. {6}, 8. {7}",
                Categories.Yatzy, Categories.Pair,
                Categories.TwoPairs, Categories.ThreeOfAKind, Categories.FourOfAKind, Categories.SmallStraight,
                Categories.LargeStraight, Categories.FullHouse);
            while (true)

            {
                var input = Console.ReadLine();

                if (input == "q")
                {
                    return;
                }

                int value;

                if (int.TryParse(input, out value))
                {
                    var category = (Categories) value;
                    var eventName = Enum.GetName(typeof (Categories), category);

                    var matchingEvent = typeof (Program).GetEvent(eventName);
                    Console.WriteLine("The category is " + category);


                    switch (eventName)
                    {
                        case "Yatzy":
                            OnYatzy(rolls);
                            break;
                        case "Pair":
                            OnPair(rolls);
                            break;
                        case "TwoPairs":
                            OnTwoPairs(rolls);
                            break;
                        case "ThreeOfAKind":
                            OnThreeOfAKind(rolls);
                            break;
                        case "FourOfAKind":
                            OnFourOfAKind(rolls);
                            break;
                        case "SmallStraight":
                            OnSmallStraight(rolls);
                            break;
                        case "LargeStraight":
                            OnLargeStraight(rolls);
                            break;
                       case "FullHouse":
                            OnFullHouse(rolls);
                            break;
                    }

                    
                    //if (matchingEvent != null)
                    //{
                    //    var action = new Action(() => Console.WriteLine("Category " + category + " has been handled"));
                    //    matchingEvent.AddEventHandler(null, action);
                    //}
                }

                Console.WriteLine("The Score is " + Score);
            }
        }


        private static void OnYatzy(List<int> rolls)
        {
            if (rolls.Any(x => x != rolls[0]))
            {
                Score = 0;
            }
            Console.WriteLine("Yatzy!");
            Score += 50;
        }

        private static void OnPair(List<int> rolls)
        {
            //Does the list contain any duplicates? (not 3 of kind or higher)
            //If it contains two sets which is higher?

            IEnumerable<int> duplicates = rolls.GroupBy(x => x).SelectMany(grp => grp.Skip(1));
            if (duplicates.Count() < 0)
            {
                Score = 0;
            }
            Score = 2 * duplicates.Last();
        }

        private static void OnTwoPairs(List<int> rolls)
        {
            IEnumerable<int> duplicates = rolls.GroupBy(x => x).SelectMany(grp => grp.Skip(1));
            if (duplicates.Count() != 2)
            {
                Score = 0;
            }
            Score += (2*duplicates.First()) + (2*duplicates.Last());
        }

        private static void OnThreeOfAKind(List<int> rolls)
        {
            IEnumerable<int> duplicates = rolls.GroupBy(x => x).SelectMany(grp => grp.Skip(1));
            var g = duplicates.GroupBy(i => i);
            
            foreach (var grp in g)
            {
                if (grp.Count() != 3)
                {
                    Score = 0;
                }
                Score = grp.Key * 3;
            }
        }

        private static void OnFourOfAKind(List<int> rolls)
        {
            IEnumerable<int> duplicates = rolls.GroupBy(x => x).SelectMany(grp => grp.Skip(1));
            var g = duplicates.GroupBy(i => i);

            foreach (var grp in g)
            {
                if (grp.Count() != 4)
                {
                    Score = 0;
                }
                Score += grp.Key * 4;
            }
        }

        private static void OnSmallStraight(List<int> rolls)
        {
            if (!(rolls.Contains(1) & rolls.Contains(2) & rolls.Contains(3) & rolls.Contains(4) & rolls.Contains(5)))
            {
                Score = 0;
            }
            Score += 15;
        }

        private static void OnLargeStraight(List<int> rolls)
        {
            if (!(rolls.Contains(2) && rolls.Contains(3) && rolls.Contains(4) && rolls.Contains(5) && rolls.Contains(6)))
            {
                Score = 0;
            }
            Score += 20;
        }

        private static void OnFullHouse(List<int> rolls)
        {
            IEnumerable<int> duplicates = rolls.GroupBy(x => x).SelectMany(grp => grp.Skip(1));
            var g = duplicates.GroupBy(i => i);

            foreach (var grp in g)
            {
                if (grp.Count() != 3 && g.Count() != 2)
                {
                    Score = 0;
                }
               Console.WriteLine("Full House");
               Score = g.ToList().Take(5).Sum(ints => Score);
               break;
            }
            //is there a duplicate and triple?
        }
    }
}
