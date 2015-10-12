using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata
{
     public static class PokerHands
     {
            // http://stackoverflow.com/questions/1101841/linq-how-to-perform-max-on-a-property-of-all-objects-in-a-collection-and-ret
            public static int FindHighcard(ICollection<Card> cardsinHand)
            {
                var highCardVal = 2;
                highCardVal = cardsinHand.Max(x => x.Rank);

                return highCardVal;
           }

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
