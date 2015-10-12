using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter hand for player 1 e.g : 2H 3D 5S 9C KD");
            var player1InputString = Console.ReadLine();
            
            var player1Input = MapInputToHand(player1InputString);
            
            Console.WriteLine("Enter hand for player 2 e.g : 2C 3H 4S 8C AH");
            var player2InputString = Console.ReadLine();
            var player2Input = MapInputToHand(player2InputString);

            ScoringSession scoringSession = new ScoringSession();
            scoringSession.ShowHands(player1Input.Cards, player2Input.Cards);

        }

        public static Hand MapInputToHand(string input)
        {
            Hand hand = new Hand();

            var clippedInput = input.Replace(" ", "");
            var cardStrings = Split(clippedInput, 2);

            foreach (string cardString in cardStrings)
            {
                Card card = new Card();
                card.Rank = cardString[0];
                card.Suit = Card.SuitMapper(cardString[1].ToString());
                hand.Cards.Add(card);
            }

            return hand;
        }

        // string split extension method I found 
        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
