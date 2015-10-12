using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerKata;

namespace PokerKata
{
     class ScoringSession
     {
         public enum PossibleHands
         {
             HighCard,
             Pair,
             TwoPairs,
             ThreeOfAKind,
             Straight,
             Flush,
             FullHouse,
             FourOfAKind,
             StraightFlush,
         }

        public void ShowHands(ICollection<Card> hand1, ICollection<Card> hand2)
        {
            // Handle high card calculation between two hands:
            // which item in a list matches a value that is associated with the
            // highest key of the rankMapping dict.  
            var player1Hand = determineHand(hand1);
            var player2Hand = determineHand(hand2);
            
           
            var highCard1 = PokerHands.FindHighcard(hand1);
            var highCard2 = PokerHands.FindHighcard(hand2);
            if (player1Hand > player2Hand)
                Console.WriteLine("Player 1 wins!");
            else if (player1Hand < player2Hand)
                Console.WriteLine("Player 2 wins!");
            else if (highCard1 > highCard2)
                Console.WriteLine("Player 1 wins!");
            else if (highCard1 < highCard2)
                Console.WriteLine("Player 2 wins!");
            else
            {
                Console.WriteLine("Tie!");
            }

        }

        private int determineHand(ICollection<Card> playerHand)
        {
            if (PokerHands.StraightFlushCheck(playerHand))
                return 9;
            if (PokerHands.FourOfaKindCheck(playerHand))
                return 8;
            if (PokerHands.FullHouseCheck(playerHand))
                return 7;
            if (PokerHands.FlushCheck(playerHand))
                return 6;
            if (PokerHands.StraightCheck(playerHand))
                return 5;
            if (PokerHands.ThreeOfaKind(playerHand))
                return 4;
            if (PokerHands.TwoPairCheck(playerHand))
                return 3;
            if (PokerHands.PairCheck(playerHand))
                return 2;
            return 1;
        }



   
    }
}
