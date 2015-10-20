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
                            OnTwoPairs(rolls);
                            break;
                        case "FourOfAKind":
                            OnTwoPairs(rolls);
                            break;
                        case "SmallStraight":
                            OnTwoPairs(rolls);
                            break;
                        case "LargeStraight":
                            OnTwoPairs(rolls);
                            break;
                       case "FullHouse":
                            OnTwoPairs(rolls);
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
            //why is list always null? 
            var duplicates = rolls.GroupBy(x => x).SelectMany(grp => grp.Skip(1));
            var set = new HashSet<int>(rolls);
            if (duplicates.C == 1)
            {
                //int sumOfDuplicates =  rolls.GroupBy(x => x).SelectMany(grp => grp.)
                //Score 
            }
        }

        private static void OnTwoPairs(List<int> rolls)
        {
            var handler = TwoPairs;
            if (handler != null) handler();
        }

        private static void OnThreeOfAKind(List<int> rolls)
        {
            var handler = ThreeOfAKind;
            if (handler != null) handler();
        }

        private static void OnFourOfAKind(List<int> rolls)
        {
            var handler = FourOfAKind;
            if (handler != null) handler();

        }

        private static void OnSmallStraight()
        {
            var handler = SmallStraight;
            if (handler != null) handler();
        }

        private static void OnLargeStraight()
        {
            var handler = LargeStraight;
            if (handler != null) handler();
        }

        private static void OnFullHouse()
        {
            var handler = FullHouse;
            if (handler != null) handler();
        }
    }
}
