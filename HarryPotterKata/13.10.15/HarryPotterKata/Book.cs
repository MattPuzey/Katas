using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotterKata
{
    public class Book
    {
        public int BookId { get; set; }
        public HarryPotterBookName BookName { get; set; }
        public double Price = 8;
        public double DiscountApplied { get; set; }
    }

    public enum HarryPotterBookName { PhilosephersStone, ChamberOfSecrets, PrisonerOfAzkaban, GobletOfFire, OrderOfThePhoenix }

}
