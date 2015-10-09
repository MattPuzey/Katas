using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata
{
     public static class PokerHands
     {
            public static bool StraightFlushCheck(ICollection<Card> cardsinHand)
            {
                // Are all cards in hand of the same Rank?
                var firstCard = cardsinHand.First();
                if (cardsinHand.All(s => s.Rank == firstCard.Rank))
                    return true;
                return false;
            }

            public static bool FourOfaKindCheck(ICollection<Card> cardsinHand)
            {

                return false;
            }

            public static bool FullHouseCheck(ICollection<Card> cardsInHand)
            {
                return false;
            }

            public static bool FlushCheck(ICollection<Card> cardsInHand)
            {
                return false;
            }

            public static bool StraightCheck(ICollection<Card> cardsInHand)
            {
                return false;
            }

            public static bool ThreeOfaKind(ICollection<Card> cardsInHand)
            {
                return false;
            }

            public static bool TwoPairCheck(ICollection<Card> cardsInHand)
            {
                return false;
            }

            public static bool PairCheck(ICollection<Card> cardsInHand)
            {
                return false;
            }
    }
}
