using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public static class PokerHands
    {
        public static bool StraightFlushCheck(List<Card> cardsinHand)
        {
            // Are all cards in hand of the same Rank?
            var firstCard = cardsinHand.First();
            if (cardsinHand.All(s => s.Rank == firstCard.Rank))
                return true;
            return false;
        }

        public static bool FourOfaKindCheck(List<Card> cardsinHand)
        {

            return false;
        }

        public static bool FullHouseCheck(List<Card> cardsInHand)
        {
            return false;
        }

        public static bool FlushCheck(List<Card> cardsInHand)
        {
            return false;
        }

        public static bool StraightCheck(List<Card> cardsInHand)
        {
            return false;
        }

        public static bool ThreeOfaKind(List<Card> cardsInHand)
        {
            return false;
        }

        public static bool TwoPairCheck(List<Card> cardsInHand)
        {
            return false;
        }

        public static bool PairCheck(List<Card> cardsInHand)
        {
            return false;
        }

    }
}
