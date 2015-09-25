using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Poker
{
    public class Deck
    {
        public static List<Card> CardsAlreadyDrawn = new List<Card>();
        public const int FullDeckSize = 52;
        public static int CurrentDeckSize = FullDeckSize;

        public List<Card> GetNewHand()
        {
            //Keep drawing a new card from the deck until the drawn card has not
            //been drawn is drawn already. If it has not been drawn add it to 
            //the 'cards' list of cards already drawn and then add to this hand.

            HandConstructor newHand = new HandConstructor();
            List<Card> cardsInHand = newHand.Hand;
            
            while (cardsInHand != null && cardsInHand.Count <= 5)
            {

                Card drawnCard = newHand.DrawCardFromDeck();
                if (newHand.CurrentCardIsDuplicate(drawnCard))
                {
                    drawnCard = null;
                }
                CardsAlreadyDrawn.Add(drawnCard);
                --CurrentDeckSize;
                cardsInHand.Add(drawnCard);
            }
            return cardsInHand;
        }


    }
}
