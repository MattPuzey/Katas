using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {

        // Scoring code is bloated  but is composed of resuable methods, 
        // for example if you were to expand the game to work for more than two players.
        // Not a proper TDD approach to the kata.
        static void Main(string[] args)
        {
            Deck gameDeck = new Deck();
            ScoringSession newSession = new ScoringSession();

            List<Card> player1Hand = gameDeck.GetNewHand();
            List<Card> player2Hand = gameDeck.GetNewHand();

            
            newSession.ShowHands(player1Hand, player2Hand);


            
        }

        

    }

}
