using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata
{
    public class Card
    {
        public SuitEnum Suit { get; set; }
        public int Rank { get; set; }

        public enum SuitEnum
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
            
        }

       

        public static SuitEnum SuitMapper(string input)
        {
            SuitEnum suit = SuitEnum.Clubs; 
            switch (input)
            {
                case "H":
                    suit = SuitEnum.Hearts;
                    break;
                case "C":
                    suit = SuitEnum.Clubs;
                    break;
                case "D":
                    suit = SuitEnum.Diamonds;
                    break;
                case "S":
                    suit = SuitEnum.Spades;
                    break;
                   
            }
            return suit;
        } 

        public override string ToString()
        {
            string output = "";
            if (Rank > 10)
            {
                switch (Rank)
                {
                    case 11:
                        output += "Jack";
                        break;
                    case 12:
                        output += "Queen";
                        break;
                    case 13:
                        output += "King";
                        break;
                    case 14:
                        output += "Ace";
                        break;
                }
            }
            else
            {
                output += Rank;
            }
            output += " of " + System.Enum.GetName(typeof(SuitEnum), Suit);
            return output;
        }
    }
}

  



