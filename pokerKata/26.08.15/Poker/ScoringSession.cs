using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class ScoringSession
    {
        //Ordered dict necessary for foreach iterations?
        private Dictionary<int, string> rankMapping = new Dictionary<int, string>()
        {
            {1, "A"},{2, "K"},{3, "Q"},{4, "J"},{5, "10"},{6, "11"},{7, "9"},{8, "8"},
            {9, "7"}, {10, "6"}, {11, "5"}, {12, "4"}, {13, "3"}, {14, "2"}
            //An enumerated type should be used for this instead.
        };

        private Dictionary<int, string> pokerHandsMapping = new Dictionary<int, string>()
        {
            {1, "Straight flush"}, {2, "Four of a kind"}, {3, "Full House"}, 
            {4, "Flush"}, {5, "Straight"}, {6, "Three of A Kind"}, {7, "Two Pairs"},
            {8, "Pair"}, {9, "High Card"}
            // An enumerated type should be used for this instead.
        };

   

        public void ShowHands(List<Card> hand1, List<Card> hand2)
        {
            // Handle high card calculation between two hands:
            // which item in a list matches a value that is associated with the
            // highest key of the rankMapping dict.  
            var player1Hand = determineHand(hand1);
            var player2Hand = determineHand(hand2);
            
            Console.Write("Player 1 hand is: ");
            // These prints need formatting properly.  
            foreach (Card card in hand1)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(card))
                {
                    var name = descriptor.Name;
                    var value = descriptor.GetValue(card);
                    Console.WriteLine("{0}={1}", name, value);
                }
            }
            Console.Write("Player 2 hand is: ");
            foreach (Card card in hand2)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(card))
                {
                    var name = descriptor.Name;
                    var value = descriptor.GetValue(card);
                    Console.WriteLine("{0}={1}", name, value);
                }
            }
            var highCard1 = FindHighcard(hand1);
            var highCard2 = FindHighcard(hand2);
            if (player1Hand > player2Hand)
                Console.WriteLine("Player 1 wins!");
            else if (player1Hand < player2Hand)
                Console.WriteLine("Player 2 wins!");
            else if (highCard1 > highCard2)
                Console.WriteLine("Player 1 wins!");
            else
            {
                Console.WriteLine("Tie!");
            }

        }

        private int determineHand(List<Card> playerHand)
        {
            if (playerHand != null && PokerHands.StraightFlushCheck(playerHand))
                return 1;
            if (PokerHands.FourOfaKindCheck(playerHand))
                return 2;
            if (PokerHands.FullHouseCheck(playerHand))
                return 3;
            if (PokerHands.FlushCheck(playerHand))
                return 4;
            if (PokerHands.StraightCheck(playerHand))
                return 5;
            if (PokerHands.ThreeOfaKind(playerHand))
                return 6;
            if (PokerHands.TwoPairCheck(playerHand))
                return 7;
            if (PokerHands.PairCheck(playerHand))
                return 8;
            return 9;
        }

        

        private int FindHighcard(List<Card> cardsinHand)
        {
            var highCardVal = 2; 
            // for each value in rankMapping values, is the value in the hand?
            //exit when it is, exit and make note of exiting value.
            foreach (KeyValuePair<int, string> rankKeyValuePair in rankMapping)
            {
                
                var matches = cardsinHand.Where(p => p.Rank == rankKeyValuePair.Value);
                // why is never null? what happens if match isn't found. 
                if (matches != null)
                {
                    highCardVal = rankKeyValuePair.Key;
                    break;
                }
            }

            return highCardVal;
        }

   
    }

}
